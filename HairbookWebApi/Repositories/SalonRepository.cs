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
    public class SalonRepository : Repository<Salon>, ISalonRepository
    {
        private readonly HairbookContext _context;

        public SalonRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salon>> GetSalonsAsync(int index, int count, Expression<Func<Salon, bool>> predicate = null, Expression<Func<Salon, object>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<Salon> result = _context.Salons;

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
