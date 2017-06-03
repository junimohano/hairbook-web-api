using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Database;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HairbookContext _context;
        public IUsersRepository Users { get; private set; }
        public ISalonsRepository Salons { get; private set; }
        public IPostsRepository Posts { get; private set; }
        
        public UnitOfWork(HairbookContext context)
        {
            _context = context;
            Users = new UsersRepository(_context);
            Salons = new SalonsRepository(_context);
            Posts = new PostsRepository(_context);
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
