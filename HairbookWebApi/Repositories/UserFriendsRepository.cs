using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Database;
using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HairbookWebApi.Repositories
{
    public class UserFriendsRepository : Repository<UserFriend>, IUserFriendsRepository
    {
        private readonly HairbookContext _context;

        public UserFriendsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserFriend>> GetUserFriendsAsync(int index, int count, Expression<Func<UserFriend, bool>> predicate = null, Expression<Func<UserFriend, int>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<UserFriend> result = GetUserFriends();

            if (count != 0)
                result = result.Skip(index)
                             .Take(count);

            if (isReadonly)
                result = result.AsNoTracking();

            if (predicate != null)
                result = result.Where(predicate);

            if (orderBy != null)
                result = result.OrderByDescending(orderBy);

            return await result.ToListAsync();
        }

        public async Task<UserFriend> GetUserFriendAsync(int userFriendId)
        {
            var result = await GetUserFriends()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserFriendId == userFriendId);

            return result;
        }

        private IIncludableQueryable<UserFriend, User> GetUserFriends()
        {
            return _context.UserFriends
                .Include(x => x.CreatedUser)
                .Include(x => x.Friend);
        }

        public int GetTotalUserFollowing(int userId)
        {
            return GetUserFriends()
                .AsNoTracking()
                .Count(x => x.CreatedUserId == userId);
        }

        public int GetTotalUserFollowers(int userId)
        {
            return GetUserFriends()
                .AsNoTracking()
                .Count(x => x.FriendId == userId);
        }

    }
}
