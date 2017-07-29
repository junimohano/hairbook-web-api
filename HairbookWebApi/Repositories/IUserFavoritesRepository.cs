using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IUserFavoritesRepository : IRepository<UserFavorite>
    {
        Task<IEnumerable<UserFavorite>> GetUserFavoritesAsync(int index, int count, Expression<Func<UserFavorite, bool>> predicate = null, Expression<Func<UserFavorite, int>> orderByDescending = null, bool isReadonly = true);
    }
}
