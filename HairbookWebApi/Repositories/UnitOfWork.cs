using HairbookWebApi.Database;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace HairbookWebApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HairbookContext _context;

        public IUsersRepository Users { get; }
        public IUserFriendsRepository UserFriends { get; }
        public ISalonsRepository Salons { get; }

        public IPostsRepository Posts { get; }
        public IPostEvaluationsRepository PostEvaluations { get; }
        public IPostUploadsRepository PostUploads { get; }
        public IPostCommentsRepository PostComments { get; }
        
        public UnitOfWork(HairbookContext context, IHostingEnvironment environment)
        {
            _context = context;
            Users = new UsersRepository(_context);
            UserFriends = new UserFriendsRepository(_context);
            Salons = new SalonsRepository(_context);
            Posts = new PostsRepository(_context, environment);
            PostEvaluations = new PostEvaluationsRepository(_context);
            PostUploads = new PostUploadsRepository(_context);
            PostComments = new PostCommentsRepository(_context);
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
