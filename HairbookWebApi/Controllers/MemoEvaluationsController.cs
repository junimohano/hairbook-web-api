using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HairbookWebApi.Controllers
{
    //[Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MemoEvaluationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemoEvaluationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MemoEvaluationDto>> Get([FromQuery] int memoId)
        {
            var models = await _unitOfWork.MemoEvaluations.GetMemoEvaluationsAsync(memoId);

            return _mapper.Map<IEnumerable<MemoEvaluation>, IEnumerable<MemoEvaluationDto>>(models);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] MemoEvaluationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.MemoId)
                return BadRequest();

            var model = _mapper.Map<MemoEvaluationDto, MemoEvaluation>(dto);

            try
            {
                model.UpdatedDate = new DateTime();

                _unitOfWork.MemoEvaluations.Update(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MemoEvaluationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<MemoEvaluationDto, MemoEvaluation>(dto);

            try
            {
                model.CreatedDate = new DateTime();

                _unitOfWork.MemoEvaluations.Add(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.MemoId }, _mapper.Map<MemoEvaluation, MemoEvaluationDto>(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.MemoEvaluations.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.MemoEvaluations.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<MemoEvaluation, MemoEvaluationDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}