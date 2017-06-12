using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HairbookWebApi.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get([FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var models = await _unitOfWork.Users.GetUsersAsync(index, count);

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id, [FromQuery] string userKey)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Users.SingleOrDefaultAsync(x => id == 0 ? x.UserKey == userKey : x.UserId == id);

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<User, UserDto>(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.UserId)
                return BadRequest();

            var model = _mapper.Map<UserDto, User>(dto);

            try
            {
                model.UpdatedDate = new DateTime();

                _unitOfWork.Users.Update(model);
                
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<UserDto, User>(dto);

            try
            {
                model.CreatedDate = new DateTime();

                _unitOfWork.Users.Add(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.UserId }, _mapper.Map<User, UserDto>(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Users.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.Users.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<User, UserDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}