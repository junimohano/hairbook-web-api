using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Repositories
{
    public class PostsRepository : Repository<Post>, IPostsRepository
    {
        private readonly HairbookContext _context;

        public PostsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Post>> GetPostsAsync(int index, int count, int userId, Expression<Func<Post, bool>> predicate = null, Expression<Func<Post, object>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<Post> result = _context.Posts
                .Include(x => x.Customer)
                .Include(x => x.Salon)
                .Include(x => x.PostEvaluations)
                .Include(x => x.PostComments)
                .Include(x => x.PostHairTypes)
                    .ThenInclude(x => x.HairType)
                .Include(x => x.PostHairMenus)
                    .ThenInclude(x => x.HairMenu)
                .Include(x => x.PostUploads);

            if (isReadonly)
                result = result.AsNoTracking();

            if (predicate != null)
                result = result.Where(predicate);
            
            if (orderBy != null)
                result = result.OrderBy(orderBy);

            if (count != 0)
                result = result.Skip(index)
                             .Take(count);

            return await result.ToListAsync();
        }

        public async void AddPost(Post post)
        {
            var model = await _context.Posts.AddAsync(post);

            if (post.PostHairTypes.Any())
            {
                foreach (var hairType in post.PostHairTypes)
                    hairType.PostId = model.Entity.PostId;

                await _context.PostHairTypes.AddRangeAsync(post.PostHairTypes);
            }

            if (post.PostHairMenus.Any())
            {
                foreach (var hairMenu in post.PostHairMenus)
                    hairMenu.PostId = model.Entity.PostId;

                await _context.PostHairMenus.AddRangeAsync(post.PostHairMenus);
            }

        }

        public void UpdatePost(Post post)
        {
            var model = _context.Posts.Update(post);

            if (post.PostHairTypes.Any())
            {
                var updateHairTypes = post.PostHairTypes.Where(x => x.PostHairTypeId != 0).ToList();
                if (updateHairTypes.Any())
                    _context.PostHairTypes.UpdateRange(updateHairTypes);

                var newHairTypes = post.PostHairTypes.Where(x => x.PostHairTypeId == 0).ToList();
                foreach (var hairType in newHairTypes)
                    hairType.PostId = model.Entity.PostId;
                if (newHairTypes.Any())
                    _context.PostHairTypes.AddRange(newHairTypes);
            }


            if (post.PostHairMenus.Any())
            {
                var updateHairMenus = post.PostHairMenus.Where(x => x.PostHairMenuId != 0).ToList();
                if (updateHairMenus.Any())
                    _context.PostHairMenus.UpdateRange(updateHairMenus);

                var newHairMenus = post.PostHairMenus.Where(x => x.PostHairMenuId == 0).ToList();
                foreach (var hairMenu in newHairMenus)
                    hairMenu.PostId = model.Entity.PostId;
                if (newHairMenus.Any())
                    _context.PostHairMenus.AddRange(newHairMenus);
            }
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
                _context.PostUploads.RemoveRange(post.PostUploads);

            _context.Posts.Remove(post);
        }

        public async Task<IEnumerable<HairMenu>> GetMenusAsync()
        {
            return await _context.HairMenus.ToListAsync();
        }

        public async Task<IEnumerable<HairType>> GetHairTypesAsync()
        {
            return await _context.HairTypes.ToListAsync();
        }
    }
}
