using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface ISalonsRepository : IRepository<Salon>
    {
        Task<IEnumerable<Salon>> GetSalonsAsync(int index, int count, Expression<Func<Salon, bool>> predicate = null, Expression<Func<Salon, object>> orderBy = null, bool isReadonly = true);
    }
}
