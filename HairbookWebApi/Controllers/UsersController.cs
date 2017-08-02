using AutoMapper;
using HairbookWebApi.Auth;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly IHostingEnvironment _environment;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper, IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = environment;
        }

        [Authorize(AuthOption.TokenType)]
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get([FromQuery] int userId, [FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] string search = null)
        {
            Expression<Func<User, bool>> predicate = null;
            if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                predicate = x => x.UserName.Contains(search);

            var models = await _unitOfWork.Users.GetUsersAsync(index, count, predicate, x => x.UserId);

            var modelDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(models);

            foreach (var modelDto in modelDtos)
            {
                modelDto.IsFollowing = modelDto.Userfollowers.Any(x => x.CreatedUserId == userId && x.FriendId == modelDto.UserId);
                modelDto.UserFollowing = modelDto.UserFollowing.Take(0);
                modelDto.Userfollowers = modelDto.Userfollowers.Take(0);
            }

            return modelDtos;
        }

        [Authorize(AuthOption.TokenType)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Users.FindAsync(id);

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
                model.UpdatedDate = DateTime.Now;

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
                model.CreatedDate = DateTime.Now;

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

        [Authorize(AuthOption.TokenType)]
        [HttpGet("GetByUserName/{userName}")]
        public async Task<UserDto> GetByUserName([FromRoute] string userName, [FromQuery] int userId)
        {
            var model = await _unitOfWork.Users.GetUserAsync(userName);

            var userDto = _mapper.Map<User, UserDto>(model);
            userDto.TotalUserFollowers = _unitOfWork.UserFriends.GetTotalUserFollowers(userDto.UserId);
            userDto.TotalUserFollowing = _unitOfWork.UserFriends.GetTotalUserFollowing(userDto.UserId);
            userDto.TotalUserPosts = _unitOfWork.Posts.GetTotalUserPosts(userDto.UserId);
            userDto.IsFollowing = userDto.Userfollowers.Any(x => x.CreatedUserId == userId && x.FriendId == userDto.UserId);
            userDto.Userfollowers = userDto.Userfollowers.Take(0);
            userDto.UserFollowing = userDto.UserFollowing.Take(0);

            return userDto;
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

        [HttpPost("PostUserImage/{userId}")]
        public async Task<IActionResult> Post(IFormFile uploadedFile, [FromRoute] int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.FindAsync(userId);
            if (user == null)
                return BadRequest();

            try
            {
                var uploadPath = Path.Combine("uploads", "users", $"{DateTime.Now.Ticks}_{new FileInfo(uploadedFile.FileName).Name}");

                if (uploadedFile.Length > 0)
                {
                    if (user.Image != null)
                    {
                        var fileInfo = new FileInfo(Path.Combine(_environment.WebRootPath, user.Image));
                        if (fileInfo.Exists)
                            fileInfo.Delete();
                    }

                    using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, uploadPath), FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    user.Image = uploadPath;
                    user.UpdatedDate = DateTime.Now;
                    user.UpdatedUserId = user.CreatedUserId;

                    _unitOfWork.Users.Update(user);
                    await _unitOfWork.Complete();

                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}