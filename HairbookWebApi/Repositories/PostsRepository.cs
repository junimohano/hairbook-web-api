using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query;

namespace HairbookWebApi.Repositories
{
    public class PostsRepository : Repository<Post>, IPostsRepository
    {
        private readonly HairbookContext _context;
        private readonly IHostingEnvironment _environment;

        public PostsRepository(HairbookContext context, IHostingEnvironment environment) : base(context)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<ICollection<Post>> GetPostsAsync(int index, int count, Expression<Func<Post, bool>> predicate = null, Expression<Func<Post, int>> orderByDescending = null, bool isReadonly = true)
        {
            IQueryable<Post> result = GetPost();

            if (isReadonly)
                result = result.AsNoTracking();

            if (predicate != null)
                result = result.Where(predicate);

            if (orderByDescending != null)
                result = result.OrderByDescending(orderByDescending);

            if (count != 0)
                result = result.Skip(index)
                             .Take(count);

            return await result.ToListAsync();
        }

        public async Task<Post> GetPostAsync(int postId)
        {
            var result = await GetPost()
                            .AsNoTracking()
                            .SingleOrDefaultAsync(x => x.PostId == postId);

            return result;
        }

        private IIncludableQueryable<Post, IEnumerable<PostUpload>> GetPost()
        {
            return _context.Posts
                .Include(x => x.CreatedUser)
                .Include(x => x.Customer)
                .Include(x => x.Salon)
                .Include(x => x.PostEvaluations)
                .Include(x => x.PostComments)
                    .ThenInclude(x => x.CreatedUser)
                .Include(x => x.PostHairTypes)
                    .ThenInclude(x => x.HairType)
                .Include(x => x.PostHairMenus)
                    .ThenInclude(x => x.HairMenu)
                .Include(x => x.PostHairMenus)
                    .ThenInclude(x => x.HairSubMenu)
                .Include(x => x.PostUploads);
        }

        public async void AddPost(Post post)
        {
            if (post.CustomerId == 0)
            {
                post.Customer.CreatedDate = post.CreatedDate;
                post.Customer.CreatedUserId = post.CreatedUserId;
            }

            var model = await _context.Posts.AddAsync(post);

            if (post.PostHairTypes.Any())
            {
                foreach (var hairType in post.PostHairTypes)
                {
                    hairType.PostId = model.Entity.PostId;
                    hairType.CreatedUserId = post.CreatedUserId;
                    hairType.CreatedDate = post.CreatedDate;
                }

                await _context.PostHairTypes.AddRangeAsync(post.PostHairTypes);
            }

            if (post.PostHairMenus.Any())
            {
                foreach (var hairMenu in post.PostHairMenus)
                {
                    hairMenu.PostId = model.Entity.PostId;
                    hairMenu.CreatedUserId = post.CreatedUserId;
                    hairMenu.CreatedDate = post.CreatedDate;
                }

                await _context.PostHairMenus.AddRangeAsync(post.PostHairMenus);
            }

        }

        public void UpdatePost(Post post)
        {
            if (post.PostHairTypes.Any())
            {
                var updateHairTypes = post.PostHairTypes.Where(x => x.PostHairTypeId != 0).ToList();
                foreach (var hairType in updateHairTypes)
                {
                    hairType.UpdatedDate = DateTime.Now;
                    hairType.UpdatedUserId = post.UpdatedUserId;
                }
                if (updateHairTypes.Any())
                    _context.PostHairTypes.UpdateRange(updateHairTypes);

                var newHairTypes = post.PostHairTypes.Where(x => x.PostHairTypeId == 0).ToList();
                foreach (var hairType in newHairTypes)
                {
                    hairType.PostId = post.PostId;
                    hairType.CreatedDate = DateTime.Now;
                    hairType.CreatedUserId = post.CreatedUserId;
                }
                if (newHairTypes.Any())
                    _context.PostHairTypes.AddRange(newHairTypes);
            }
            
            if (post.PostHairMenus.Any())
            {
                var updateHairMenus = post.PostHairMenus.Where(x => x.PostHairMenuId != 0).ToList();
                foreach (var hairMenu in updateHairMenus)
                {
                    hairMenu.UpdatedDate = DateTime.Now;
                    hairMenu.UpdatedUserId = post.UpdatedUserId;
                }
                if (updateHairMenus.Any())
                    _context.PostHairMenus.UpdateRange(updateHairMenus);

                var newHairMenus = post.PostHairMenus.Where(x => x.PostHairMenuId == 0).ToList();
                foreach (var hairMenu in newHairMenus)
                {
                    hairMenu.PostId = post.PostId;
                    hairMenu.CreatedDate = DateTime.Now;
                    hairMenu.CreatedUserId = post.CreatedUserId;
                }
                if (newHairMenus.Any())
                    _context.PostHairMenus.AddRange(newHairMenus);
            }

            _context.Posts.Update(post);
        }

        public void DeletePost(Post post)
        {
            if (post.PostHairMenus.Any())
                _context.PostHairMenus.RemoveRange(post.PostHairMenus);

            if (post.PostHairTypes.Any())
                _context.PostHairTypes.RemoveRange(post.PostHairTypes);

            if (post.PostEvaluations.Any())
                _context.PostEvaluations.RemoveRange(post.PostEvaluations);

            if (post.PostUploads.Any())
            {
                foreach (var postUpload in post.PostUploads)
                {
                    var fileInfo = new FileInfo(Path.Combine(_environment.WebRootPath, postUpload.Path));
                    if (fileInfo.Exists)
                        fileInfo.Delete();
                }
                _context.PostUploads.RemoveRange(post.PostUploads);
            }

            if (post.PostComments.Any())
                _context.PostComments.RemoveRange(post.PostComments);

            _context.Posts.Remove(post);
        }

        public async Task<IEnumerable<HairMenu>> GetMenusAsync()
        {
            return await _context.HairMenus
                        .Include(x => x.HairSubMenus)
                        .ToListAsync();
        }

        public async Task<IEnumerable<HairType>> GetHairTypesAsync()
        {
            return await _context.HairTypes.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int userId)
        {
            return await _context.Customers.Where(x => x.CreatedUserId == userId).ToListAsync();
        }
    }
}
