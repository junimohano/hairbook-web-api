using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IPostsRepository : IRepository<Post>
    {
        Task<ICollection<Post>> GetPostsAsync(int index, int count, int userId, Expression<Func<Post, bool>> predicate = null, Expression<Func<Post, object>> orderBy = null, bool isReadonly = true);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);

        Task<IEnumerable<HairMenu>> GetMenusAsync();
        Task<IEnumerable<HairType>> GetHairTypesAsync();
    }
}
