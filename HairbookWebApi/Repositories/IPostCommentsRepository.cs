using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Repositories
{
    public interface IPostCommentsRepository : IRepository<PostComment>
    {
        Task<ICollection<PostComment>> GetPostCommentsAsync(int index, int count, Expression<Func<PostComment, bool>> predicate = null, Expression<Func<PostComment, int>> orderByDescending = null, bool isReadonly = true);
        Task<PostComment> GetPostCommentAsync(int postCommentId);
    }
}
