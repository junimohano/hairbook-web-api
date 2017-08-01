using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HairbookWebApi.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private readonly HairbookContext _context;

        public UsersRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(int index, int count, Expression<Func<User, bool>> predicate = null, Expression<Func<User, int>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<User> result = GetUsers();

            if (isReadonly)
                result = result.AsNoTracking();

            if (predicate != null)
                result = result.Where(predicate);

            if (orderBy != null)
                result = result.OrderBy(orderBy);

            if (count != 0)
                result = result.Skip(index)
                             .Take(count);

            return await result.ToListAsync();
        }

        public async Task<User> GetUserAsync(string userName)
        {
            var result = await GetUsers()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserName == userName);

            return result;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var result = await GetUsers()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserId == userId);

            return result;
        }
        
        private IIncludableQueryable<User, IEnumerable<UserFriend>> GetUsers()
        {
            return _context.Users
                .Include(x => x.Salon)
                .Include(x => x.CreatedUser)
                .Include(x => x.UpdatedUser)
                .Include(x => x.UserFollowing)
                .Include(x => x.Userfollowers);
        }

    }
}
