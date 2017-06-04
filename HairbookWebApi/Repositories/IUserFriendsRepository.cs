using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IUserFriendsRepository : IRepository<UserFriend>
    {
        Task<IEnumerable<UserFriend>> GetUserFriendsAsync(int index, int count, Expression<Func<UserFriend, bool>> predicate = null, Expression<Func<UserFriend, object>> orderBy = null, bool isReadonly = true);
    }
}
