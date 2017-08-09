using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IPostFavoritesRepository : IRepository<PostFavorite>
    {
        Task<IEnumerable<PostFavorite>> GetPostFavoritesAsync(int index, int count, Expression<Func<PostFavorite, bool>> predicate = null, Expression<Func<PostFavorite, DateTime>> orderByDescending1 = null, Expression<Func<PostFavorite, int>> orderByDescending2 = null, bool isReadonly = true);
    }
}
