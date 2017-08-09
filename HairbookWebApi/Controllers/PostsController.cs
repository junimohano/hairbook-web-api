using AutoMapper;
using HairbookWebApi.Auth;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
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
        public async Task<IEnumerable<PostDto>> Get([FromQuery] int userId, [FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] string userName = "", [FromQuery] string userNameParam = "", [FromQuery] PostSearchType postSearchType = PostSearchType.UsersCustomer, [FromQuery] string search = null)
        {
            IEnumerable<Post> posts;

            if (postSearchType == PostSearchType.Favorite)
            {
                Expression<Func<PostFavorite, bool>> predicate = null;
                if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                    predicate = x => (x.Post.AccessType == AccessType.Public || x.Post.AccessType == AccessType.OnlyMe && x.Post.CreatedUserId == userId) && x.CreatedUserId == userId && x.Post.Title.Contains(search);
                else
                    predicate = x => (x.Post.AccessType == AccessType.Public || x.Post.AccessType == AccessType.OnlyMe && x.Post.CreatedUserId == userId) && x.CreatedUserId == userId;

                var models = await _unitOfWork.PostFavorites.GetPostFavoritesAsync(index, count, predicate, x => x.Post.Date, x => x.PostId);
                posts = models.Select(x => x.Post);
            }
            else
            {
                Expression<Func<Post, bool>> predicate = null;
                switch (postSearchType)
                {
                    case PostSearchType.ExplorersAll:
                        if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                            predicate = x => x.AccessType == AccessType.Public && x.Title.Contains(search);
                        else
                            predicate = x => x.AccessType == AccessType.Public;
                        break;

                    case PostSearchType.ExplorersFollowingOnly:
                        var userFriends = await _unitOfWork.UserFriends.WhereAsync(x => x.CreatedUser.UserName == userName);
                        if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                            predicate = x => x.AccessType == AccessType.Public && x.Title.Contains(search) && (userFriends.Any(x1 => x1.FriendId == x.CreatedUserId) || x.CreatedUser.UserName == userName);
                        else
                            predicate = x => x.AccessType == AccessType.Public && (userFriends.Any(x1 => x1.FriendId == x.CreatedUserId) || x.CreatedUser.UserName == userName);
                        break;

                    case PostSearchType.UsersCustomer:
                        // visit other user's home
                        if (userName != userNameParam)
                        {
                            if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                                predicate = x => x.AccessType == AccessType.Public && x.CreatedUser.UserName == userNameParam && x.Customer.Name.Contains(search);
                            else
                                predicate = x => x.AccessType == AccessType.Public && x.CreatedUser.UserName == userNameParam;
                        }
                        // user's home
                        else
                        {
                            if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                                predicate = x => x.CreatedUser.UserName == userName && x.Customer.Name.Contains(search);
                            else
                                predicate = x => x.CreatedUser.UserName == userName;
                        }
                        break;

                    case PostSearchType.UsersTitle:
                        // visit other user's home
                        if (userName != userNameParam)
                        {
                            if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                                predicate = x => x.AccessType == AccessType.Public && x.CreatedUser.UserName == userNameParam && x.Title.Contains(search);
                            else
                                predicate = x => x.AccessType == AccessType.Public && x.CreatedUser.UserName == userNameParam;
                        }
                        // user's home
                        else
                        {
                            if (!string.IsNullOrEmpty(search) && search != "undefined" && search != "null")
                                predicate = x => x.CreatedUser.UserName == userName && x.Title.Contains(search);
                            else
                                predicate = x => x.CreatedUser.UserName == userName;
                        }
                        break;
                }

                posts = await _unitOfWork.Posts.GetPostsAsync(index, count, predicate, x => x.Date, x => x.PostId);
            }

            // Comment only 3
            var modelDtos = _mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(posts);
            foreach (var modelDto in modelDtos)
            {
                modelDto.TotalPostComments = modelDto.PostComments.Count();
                modelDto.PostComments = modelDto.PostComments.Skip(modelDto.TotalPostComments - 3).Take(3);

                modelDto.TotalPostEvaluations = modelDto.PostEvaluations.Count();
                modelDto.IsEvaluation = modelDto.PostEvaluations.Any(x => x.CreatedUserId == userId);
                modelDto.IsFavorite = modelDto.PostFavorites.Any(x => x.CreatedUserId == userId);
                modelDto.PostEvaluations = modelDto.PostEvaluations.Take(0);
                modelDto.PostFavorites = modelDto.PostFavorites.Take(0);
            }

            return modelDtos;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id, [FromQuery] int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.Posts.GetPostAsync(id);

            if (model == null)
                return NotFound();

            // Comment only 3
            var modelDto = _mapper.Map<Post, PostDto>(model);
            modelDto.TotalPostComments = modelDto.PostComments.Count();
            modelDto.PostComments = modelDto.PostComments.Skip(modelDto.TotalPostComments - 3).Take(3);

            modelDto.TotalPostEvaluations = modelDto.PostEvaluations.Count();
            modelDto.IsEvaluation = modelDto.PostEvaluations.Any(x => x.CreatedUserId == userId);
            modelDto.IsFavorite = modelDto.PostFavorites.Any(x => x.CreatedUserId == userId);
            modelDto.PostEvaluations = modelDto.PostEvaluations.Take(0);
            modelDto.PostFavorites = modelDto.PostFavorites.Take(0);

            return Ok(modelDto);
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
                model.UpdatedDate = DateTime.Now;

                _unitOfWork.Posts.UpdatePost(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("Get", new { id = model.PostId }, _mapper.Map<Post, PostDto>(model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<PostDto, Post>(dto);

            try
            {
                model.CreatedDate = DateTime.Now;

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

        [HttpGet("HairMenus")]
        public async Task<IActionResult> GetHairMenus()
        {
            var model = await _unitOfWork.Posts.GetMenusAsync();

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<HairMenu>, IEnumerable<HairMenuDto>>(model));
        }

        [HttpGet("HairTypes")]
        public async Task<IActionResult> GetHairTypes()
        {
            var model = await _unitOfWork.Posts.GetHairTypesAsync();

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<HairType>, IEnumerable<HairTypeDto>>(model));
        }

        [HttpGet("Customers/{userId}")]
        public async Task<IActionResult> GetCustomers([FromRoute] int userId)
        {
            var model = await _unitOfWork.Posts.GetCustomersAsync(userId);

            if (model == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}