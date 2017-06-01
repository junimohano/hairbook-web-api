using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUsersAsync(int index, int count, Expression<Func<User, bool>> predicate = null, Expression<Func<User, object>> orderBy = null, bool isReadonly = true);
        Task<User> GetUserAsync(Expression<Func<User, bool>> predicate, bool isReadonly = true);
    }
}
