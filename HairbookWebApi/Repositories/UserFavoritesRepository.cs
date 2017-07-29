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
    public class UserFavoritesRepository : Repository<UserFavorite>, IUserFavoritesRepository
    {
        private readonly HairbookContext _context;

        public UserFavoritesRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserFavorite>> GetUserFavoritesAsync(int index, int count, Expression<Func<UserFavorite, bool>> predicate = null, Expression<Func<UserFavorite, int>> orderByDescending = null, bool isReadonly = true)
        {
            IQueryable<UserFavorite> result = GetUserFavorites();

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

        private IIncludableQueryable<UserFavorite, Post> GetUserFavorites()
        {
            return _context.UserFavorites
                .Include(x => x.CreatedUser)
                .Include(x => x.Post);
        }
    }
}
