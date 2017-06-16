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
    //[Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostEvaluationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostEvaluationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostEvaluationDto>> Get([FromQuery] int postId)
        {
            var models = await _unitOfWork.PostEvaluations.GetPostEvaluationsAsync(postId);

            return _mapper.Map<IEnumerable<PostEvaluation>, IEnumerable<PostEvaluationDto>>(models);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PostEvaluationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.PostId)
                return BadRequest();

            var model = _mapper.Map<PostEvaluationDto, PostEvaluation>(dto);

            try
            {
                model.UpdatedDate = new DateTime();

                _unitOfWork.PostEvaluations.Update(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostEvaluationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<PostEvaluationDto, PostEvaluation>(dto);

            try
            {
                model.CreatedDate = new DateTime();

                await _unitOfWork.PostEvaluations.AddAsync(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.PostId }, _mapper.Map<PostEvaluation, PostEvaluationDto>(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.PostEvaluations.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.PostEvaluations.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<PostEvaluation, PostEvaluationDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}