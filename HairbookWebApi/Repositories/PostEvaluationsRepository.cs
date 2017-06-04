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
    public class PostEvaluationsRepository : Repository<PostEvaluation>, IPostEvaluationsRepository
    {
        private readonly HairbookContext _context;

        public PostEvaluationsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostEvaluation>> GetPostEvaluationsAsync(int postId)
        {
            IQueryable<PostEvaluation> result = _context.PostEvaluations.AsNoTracking().Where(x => x.PostId == postId);

            return await result.ToListAsync();
        }
    }
}
