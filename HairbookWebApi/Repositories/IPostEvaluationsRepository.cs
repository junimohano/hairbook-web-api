using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IPostEvaluationsRepository : IRepository<PostEvaluation>
    {
        Task<IEnumerable<PostEvaluation>> GetPostEvaluationsAsync(int postId);
    }
}
