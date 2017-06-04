using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IMemoEvaluationsRepository : IRepository<MemoEvaluation>
    {
        Task<IEnumerable<MemoEvaluation>> GetMemoEvaluationsAsync(int memoId);
    }
}
