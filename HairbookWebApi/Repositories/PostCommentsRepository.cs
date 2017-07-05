using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models.Enums;
using Microsoft.EntityFrameworkCore.Query;

namespace HairbookWebApi.Repositories
{
    public class PostCommentsRepository : Repository<PostComment>, IPostCommentsRepository
    {
        private readonly HairbookContext _context;

        public PostCommentsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<PostComment>> GetPostCommentsAsync(int index, int count, Expression<Func<PostComment, bool>> predicate = null, Expression<Func<PostComment, object>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<PostComment> result = GetPostComment();

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

        public async Task<PostComment> GetPostCommentAsync(int postCommentId)
        {
            return await GetPostComment().SingleOrDefaultAsync(x => x.PostCommentId == postCommentId);
        }

        private IIncludableQueryable<PostComment, User> GetPostComment()
        {
            return _context.PostComments
                .Include(x => x.CreatedUser);
        }

    }
}
