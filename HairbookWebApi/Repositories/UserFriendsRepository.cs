using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;

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
            IQueryable<UserFriend> result = _context.UserFriends
                                            .Include(x => x.Friend)
                                            .Include(x => x.User);

            if (count != 0)
                result = result.Skip(index)
                             .Take(count);

            if (isReadonly)
                result = result.AsNoTracking();

            if (predicate != null)
                result = result.Where(predicate);

            if (orderBy != null)
                result = result.OrderBy(orderBy);

            return await result.ToListAsync();
        }
    }
}
