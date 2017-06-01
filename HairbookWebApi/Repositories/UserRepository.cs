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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly HairbookContext _context;

        public UserRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<User>> GetUsersAsync(int index, int count, Expression<Func<User, bool>> predicate = null, Expression<Func<User, object>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<User> result = _context.Users
                                .Include(x => x.Salon)
                                .Include(x=>x.CreatedUser)
                                .Include(x => x.UpdatedUser);

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

        public async Task<User> GetUserAsync(Expression<Func<User, bool>> predicate, bool isReadonly = true)
        {
            IQueryable<User> model = _context.Users
                                        .Include(x=>x.Salon)
                                        .Include(x=>x.CreatedUser)
                                        .Include(x=>x.UpdatedUser);

            if (isReadonly)
                model = model.AsNoTracking();

            return await model.SingleOrDefaultAsync(predicate);
        }
    }
}
