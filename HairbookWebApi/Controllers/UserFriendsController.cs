using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Auth;
using HairbookWebApi.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace HairbookWebApi.Controllers
{
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
        public async Task<IEnumerable<UserFriendDto>> Get([FromQuery] int userId, [FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] FriendSearchType friendSearchType = FriendSearchType.Search, [FromQuery] string search = null)
        {
            Expression<Func<UserFriend, bool>> predicate = null;
            switch (friendSearchType)
            {
                case FriendSearchType.Followers:
                    if (!string.IsNullOrEmpty(search))
                        predicate = x => x.FriendId == userId && x.Friend.UserName.Contains(search);
                    else
                        predicate = x => x.FriendId == userId;
                    break;
                case FriendSearchType.Following:
                    if (!string.IsNullOrEmpty(search))
                        predicate = x => x.CreatedUserId == userId && x.Friend.UserName.Contains(search);
                    else
                        predicate = x => x.CreatedUserId == userId;
                    break;
            }

            var models = await _unitOfWork.UserFriends.GetUserFriendsAsync(index, count, predicate, x => x.UserFriendId);

            return _mapper.Map<IEnumerable<UserFriend>, IEnumerable<UserFriendDto>>(models);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.UserFriends.FindAsync(id);
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