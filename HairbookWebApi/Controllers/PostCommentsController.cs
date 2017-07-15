using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Auth;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Controllers
{
    [Authorize(AuthOption.TokenType)]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostCommentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostCommentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostCommentDto>> Get([FromQuery] int postId, [FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var models = await _unitOfWork.PostComments.GetPostCommentsAsync(index, count, x => x.PostId == postId, x => x.PostCommentId);

            return _mapper.Map<IEnumerable<PostComment>, IEnumerable<PostCommentDto>>(models.Reverse());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.PostComments.GetPostCommentAsync(id);

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<PostComment, PostCommentDto>(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PostCommentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.PostId)
                return BadRequest();

            var model = _mapper.Map<PostCommentDto, PostComment>(dto);

            try
            {
                model.UpdatedDate = DateTime.Now;

                _unitOfWork.PostComments.Update(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCommentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<PostCommentDto, PostComment>(dto);

            try
            {
                model.CreatedDate = DateTime.Now;

                await _unitOfWork.PostComments.AddAsync(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return await Get(model.PostCommentId);
            //return CreatedAtAction("Get", new { id = model.PostCommentId }, _mapper.Map<PostComment, PostCommentDto>(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.PostComments.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.PostComments.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<PostComment, PostCommentDto>(model));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}