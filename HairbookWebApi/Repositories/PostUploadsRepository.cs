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
    public class PostUploadsRepository : Repository<PostUpload>, IPostUploadsRepository
    {
        private readonly HairbookContext _context;

        public PostUploadsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }
    }
}
