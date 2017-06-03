using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HairbookWebApi.Repositories
{
    public class PostsRepository : Repository<Post>, IPostsRepository
    {
        private readonly HairbookContext _context;

        public PostsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync(int index, int count, Expression<Func<Post, bool>> predicate = null, Expression<Func<Post, object>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<Post> result = _context.Posts
                                            .Include(x => x.Salon)
                                            .Include(x => x.Evaluations)
                                            .Include(x => x.Tags)
                                            .Include(x => x.Uploads);

            if (count != 0)
                result = result.Skip(index)
                             .Take(count);

            if (isReadonly)
                result = result.AsNoTracking();

            if (predicate != null)
                result = result.Where(predicate);

            if (orderBy != null)
                result = result.OrderBy(orderBy);

            return await result.ToListAsync();
        }

        public async void AddPost(Post post)
        {
            var model = await _context.Posts.AddAsync(post);

            if (post.Tags.Any())
            {
                foreach (var tag in post.Tags)
                    tag.PostId = model.Entity.PostId;

                await _context.PostTags.AddRangeAsync(post.Tags);
            }
        }

        public void UpdatePost(Post post)
        {
            var model = _context.Posts.Update(post);

            if (post.Tags.Any())
            {
                var updateTags = post.Tags.Where(x => x.PostTagId != 0).ToList();
                if (updateTags.Any())
                    _context.PostTags.UpdateRange(updateTags);

                var newTags = post.Tags.Where(x => x.PostTagId == 0).ToList();
                foreach (var tag in newTags)
                    tag.PostId = model.Entity.PostId;
                if (newTags.Any())
                    _context.PostTags.AddRange(newTags);
            }
        }

        public void DeletePost(Post post)
        {
            if (post.Tags.Any())
                _context.PostTags.RemoveRange(post.Tags);

            if (post.Evaluations.Any())
                _context.PostEvaluations.RemoveRange(post.Evaluations);

            if (post.Uploads.Any())
                _context.PostUploads.RemoveRange(post.Uploads);

            _context.Posts.Remove(post);
        }
    }
}
