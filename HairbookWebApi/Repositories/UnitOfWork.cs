using HairbookWebApi.Database;
using System.Threading.Tasks;

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
        
        public UnitOfWork(HairbookContext context)
        {
            _context = context;
            Users = new UsersRepository(_context);
            UserFriends = new UserFriendsRepository(_context);
            Salons = new SalonsRepository(_context);
            Posts = new PostsRepository(_context);
            PostEvaluations = new PostEvaluationsRepository(_context);
            PostUploads = new PostUploadsRepository(_context);
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
