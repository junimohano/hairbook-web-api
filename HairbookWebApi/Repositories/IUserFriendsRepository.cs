using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HairbookWebApi.Repositories
{
    public interface IUserFriendsRepository : IRepository<UserFriend>
    {
        Task<IEnumerable<UserFriend>> GetUserFriendsAsync(int userId, int index, int count, FriendSearchType friendSearchType, string search, Expression<Func<UserFriend, bool>> predicate = null, Expression<Func<UserFriend, int>> orderBy = null, bool isReadonly = true);
    }
}
