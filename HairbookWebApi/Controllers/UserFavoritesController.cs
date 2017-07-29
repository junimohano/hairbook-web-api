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
    public class UserFavoritesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserFavoritesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserFavoriteDto>> Get([FromQuery] int userId, [FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var models = await _unitOfWork.UserFavorites.GetUserFavoritesAsync(index, count, x => x.CreatedUserId == userId, x => x.UserFavoriteId);

            return _mapper.Map<IEnumerable<UserFavorite>, IEnumerable<UserFavoriteDto>>(models);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserFavoriteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<UserFavoriteDto, UserFavorite>(dto);

            try
            {
                model.CreatedDate = DateTime.Now;

                await _unitOfWork.UserFavorites.AddAsync(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.PostId }, _mapper.Map<UserFavorite, UserFavoriteDto>(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.UserFavorites.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.UserFavorites.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<UserFavorite, UserFavoriteDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}