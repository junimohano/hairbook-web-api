using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using HairbookWebApi.Auth;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairbookWebApi.Controllers
{
    [Authorize(AuthOption.TokenType)]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostFavoritesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostFavoritesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.PostFavorites.FindAsync(id);

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<PostFavorite, PostFavoriteDto>(model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostFavoriteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<PostFavoriteDto, PostFavorite>(dto);

            try
            {
                model.CreatedDate = DateTime.Now;

                await _unitOfWork.PostFavorites.AddAsync(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.PostId }, _mapper.Map<PostFavorite, PostFavoriteDto>(model));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int postId, [FromQuery] int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.PostFavorites.SingleOrDefaultAsync(x => x.PostId == postId && x.CreatedUserId == userId);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.PostFavorites.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<PostFavorite, PostFavoriteDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}