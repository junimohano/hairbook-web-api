using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.XpressionMapper.Extensions;
using HairbookWebApi.Dtos;
using HairbookWebApi.Repositories;

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

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers([FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var result = await _unitOfWork.Users.GetRangeAsync(index, count);

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id, [FromQuery] string userKey)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.SingleOrDefaultAsync(x => id == 0 ? x.UserKey == userKey : x.UserId == id);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<User, UserDto>(user));
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] UserDto user)
        {
            var data = _mapper.Map<UserDto, User>(user);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != data.UserId)
                return BadRequest();

            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_unitOfWork.Users.GetAsync(id) == null)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDto user)
        {
            var data = _mapper.Map<UserDto, User>(user);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.Users.Add(data);
            await _unitOfWork.Complete();

            return CreatedAtAction("GetUser", new { id = data.UserId }, _mapper.Map<User, UserDto>(data));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.GetAsync(id);
            if (user == null)
                return NotFound();

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.Complete();

            return Ok(_mapper.Map<User, UserDto>(user));
        }

    }
}