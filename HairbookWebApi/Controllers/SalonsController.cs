using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HairbookWebApi.Controllers
{
    //[Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SalonsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalonsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SalonDto>> Get([FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var models = await _unitOfWork.Salons.GetSalonsAsync(index, count);

            return _mapper.Map<IEnumerable<Salon>, IEnumerable<SalonDto>>(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Salons.FindAsync(id);

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<Salon, SalonDto>(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] SalonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.SalonId)
                return BadRequest();

            var model = _mapper.Map<SalonDto, Salon>(dto);

            try
            {
                model.UpdatedDate = new DateTime();

                _unitOfWork.Salons.Update(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<SalonDto, Salon>(dto);

            try
            {
                model.CreatedDate = new DateTime();

                _unitOfWork.Salons.Add(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.SalonId }, _mapper.Map<Salon, SalonDto>(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Salons.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.Salons.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<Salon, SalonDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}