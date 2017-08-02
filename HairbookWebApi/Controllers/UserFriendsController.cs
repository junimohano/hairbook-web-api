using AutoMapper;
using HairbookWebApi.Auth;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HairbookWebApi.Controllers
{
    [Produces("application/json")]
    [Authorize(AuthOption.TokenType)]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserFriendsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserFriendsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get([FromQuery] int userId, [FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] FriendSearchType friendSearchType = FriendSearchType.Following, [FromQuery] string search = null)
        {
            Expression<Func<UserFriend, bool>> predicate = null;
            var isFollowers = false;
            switch (friendSearchType)
            {
                case FriendSearchType.Followers:
                    if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                        predicate = x => x.FriendId == userId && x.CreatedUser.UserName.Contains(search);
                    else
                        predicate = x => x.FriendId == userId;

                    isFollowers = true;
                    break;
                case FriendSearchType.Following:
                    if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                        predicate = x => x.CreatedUserId == userId && x.Friend.UserName.Contains(search);
                    else
                        predicate = x => x.CreatedUserId == userId;
                    break;
            }

            var models = await _unitOfWork.UserFriends.GetUserFriendsAsync(index, count, predicate, x => x.UserFriendId);
            var user = await _unitOfWork.Users.GetUserAsync(userId);

            IEnumerable<User> users;
            if (isFollowers)
                users = models.Select(x => x.CreatedUser);
            else
                users = models.Select(x => x.Friend);

            var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
            
            foreach (var modelDto in userDtos)
            {
                modelDto.IsFollowing = user.UserFollowing.Any(x => x.CreatedUserId == userId && x.FriendId == modelDto.UserId);
                modelDto.UserFollowing = modelDto.UserFollowing?.Take(0);
                modelDto.Userfollowers = modelDto.Userfollowers?.Take(0);
            }

            return userDtos;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserFriendDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<UserFriendDto, UserFriend>(dto);

            try
            {
                model.CreatedDate = DateTime.Now;

                await _unitOfWork.UserFriends.AddAsync(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.UserFriendId }, _mapper.Map<UserFriend, UserFriendDto>(model));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int userId, [FromQuery] int friendId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.UserFriends.SingleOrDefaultAsync(x => x.CreatedUserId == userId && x.FriendId == friendId);
            if (model == null)
                return NotFound();

            try
            {
                _unitOfWork.UserFriends.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<UserFriend, UserFriendDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}