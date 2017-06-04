﻿using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairbookWebApi.Repositories
{
    public class MemoEvaluationsRepository : Repository<MemoEvaluation>, IMemoEvaluationsRepository
    {
        private readonly HairbookContext _context;

        public MemoEvaluationsRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MemoEvaluation>> GetMemoEvaluationsAsync(int memoId)
        {
            IQueryable<MemoEvaluation> result = _context.MemoEvaluations.AsNoTracking().Where(x => x.MemoId == memoId);

            return await result.ToListAsync();
        }
    }
}