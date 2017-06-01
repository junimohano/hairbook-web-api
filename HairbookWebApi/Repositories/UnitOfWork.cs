using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Database;

namespace HairbookWebApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HairbookContext _context;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(HairbookContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }
        
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
