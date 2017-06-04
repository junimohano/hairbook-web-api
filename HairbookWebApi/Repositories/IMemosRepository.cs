using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IMemosRepository : IRepository<Memo>
    {
        Task<IEnumerable<Memo>> GetMemosAsync(int index, int count, Expression<Func<Memo, bool>> predicate = null, Expression<Func<Memo, object>> orderBy = null, bool isReadonly = true);
        void AddMemo(Memo memo);
        void UpdateMemo(Memo memo);
        void DeleteMemo(Memo memo);
    }
}
