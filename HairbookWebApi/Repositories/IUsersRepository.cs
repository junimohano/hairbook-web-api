using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUsersAsync(int index, int count, Expression<Func<User, bool>> predicate = null, Expression<Func<User, int>> orderBy = null, bool isReadonly = true);
        Task<User> GetUserAsync(string userName);
        Task<User> GetUserAsync(int userId);
    }
}
