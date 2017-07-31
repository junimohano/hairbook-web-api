using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HairbookWebApi.Repositories
{
    public class PostFavoritesRepository : Repository<PostFavorite>, IPostFavoritesRepository
    {
        private readonly HairbookContext _context;

        public PostFavoritesRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostFavorite>> GetPostFavoritesAsync(int index, int count, Expression<Func<PostFavorite, bool>> predicate = null, Expression<Func<PostFavorite, int>> orderByDescending = null, bool isReadonly = true)
        {
            IQueryable<PostFavorite> result = GetPostFavorites();

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

        private IIncludableQueryable<PostFavorite, Post> GetPostFavorites()
        {
            return _context.UserFavorites
                .Include(x => x.CreatedUser)
                .Include(x => x.Post);
        }
    }
}
