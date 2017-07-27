using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Repositories
{
    public interface IPostsRepository : IRepository<Post>
    {
        Task<ICollection<Post>> GetPostsAsync(int index, int count, Expression<Func<Post, bool>> predicate = null, Expression<Func<Post, int>> orderByDescending = null, bool isReadonly = true);
        Task<Post> GetPostAsync(int postId);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);

        Task<IEnumerable<HairMenu>> GetMenusAsync();
        Task<IEnumerable<HairType>> GetHairTypesAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync(int userId);

        int GetTotalUserPosts(int userId);
    }
}
