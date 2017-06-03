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
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private readonly HairbookContext _context;

        public UsersRepository(HairbookContext context) : base(context)
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
        
    }
}
