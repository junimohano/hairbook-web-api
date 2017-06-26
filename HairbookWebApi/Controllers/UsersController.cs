using AutoMapper;
using HairbookWebApi.Auth;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace HairbookWebApi.Controllers
{
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

        [Authorize(AuthOption.TokenType)]
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get([FromQuery] int index = 0, [FromQuery] int count = 10)
        {
            var models = await _unitOfWork.Users.GetUsersAsync(index, count);

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(models);
        }

        [Authorize(AuthOption.TokenType)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Users.SingleOrDefaultAsync(x => x.UserId == id);

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<User, UserDto>(model));
        }

        [Authorize(AuthOption.TokenType)]
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

                await _unitOfWork.Users.AddAsync(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.UserId }, _mapper.Map<User, UserDto>(model));
        }

        [Authorize(AuthOption.TokenType)]
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

        //public IActionResult GetUserInfo()
        //{
        //    var claimsIdentity = User.Identity as ClaimsIdentity;

        //    return Ok(claimsIdentity?.Name);
        //}

        [HttpGet("ExistUser/{userKey}")]
        public async Task<bool> ExistUser([FromRoute] string userKey)
        {
            return await _unitOfWork.Users.AnyAsync(x => x.UserKey == userKey);
        }

        [HttpGet("ExistUserName/{userName}")]
        public async Task<bool> ExistUserName([FromRoute] string userName)
        {
            return await _unitOfWork.Users.AnyAsync(x => x.UserName == userName);
        }

        [HttpGet("GetByUserName/{userName}")]
        public async Task<User> GetByUserName([FromRoute] string userName)
        {
            return await _unitOfWork.Users.SingleOrDefaultAsync(x => x.UserName == userName);
        }

        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] UserSecretDto userSecretDto)
        {
            User user;
            bool isSuccess;

            if (userSecretDto.UserKey == null)
            {
                user = await _unitOfWork.Users.SingleOrDefaultAsync(x => x.UserName == userSecretDto.UserName);
                if (user == null)
                    return NotFound("Username is not found");

                isSuccess = user.Password == userSecretDto.Password;
            }
            else
            {
                user = await _unitOfWork.Users.SingleOrDefaultAsync(x => x.UserKey == userSecretDto.UserKey);
                if (user == null)
                    return NotFound("UserKey is not found");

                isSuccess = true;
            }

            if (isSuccess)
            {
                var requestAt = DateTime.Now;
                var expires = requestAt + AuthOption.ExpiresSpan;
                var token = GenerateToken(user, expires);

                return Ok(new TokenDto()
                {
                    RequestedAt = requestAt,
                    Expires = expires,
                    AccessToken = token,
                    User = _mapper.Map<User, UserDto>(user)
                });
            }

            return BadRequest("Password is not valid");
        }

        private string GenerateToken(User user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "TokenAuth"),
                new[] {
                    new Claim("ID", user.UserId.ToString())
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = AuthOption.Issuer,
                Audience = AuthOption.Audience,
                SigningCredentials = AuthOption.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }
    }
}