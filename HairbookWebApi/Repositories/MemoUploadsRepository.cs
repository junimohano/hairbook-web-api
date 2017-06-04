using HairbookWebApi.Database;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public class MemoUploadsRepository : Repository<MemoUpload>, IMemoUploadsRepository
    {
        private readonly HairbookContext _context;

        public MemoUploadsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }
    }
}
