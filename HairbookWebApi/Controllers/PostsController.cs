using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairbookWebApi.Controllers
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get([FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var models = await _unitOfWork.Posts.GetPostsAsync(index, count);

            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Posts.FindAsync(id);

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<Post, PostDto>(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.PostId)
                return BadRequest();

            var model = _mapper.Map<PostDto, Post>(dto);

            try
            {
                model.UpdatedDate = new DateTime();

                _unitOfWork.Posts.UpdatePost(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<PostDto, Post>(dto);

            try
            {
                model.CreatedDate = new DateTime();

                _unitOfWork.Posts.AddPost(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.PostId }, _mapper.Map<Post, PostDto>(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Posts.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.Posts.DeletePost(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<Post, PostDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}