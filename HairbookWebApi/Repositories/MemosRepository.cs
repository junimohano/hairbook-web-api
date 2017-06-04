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
    public class MemosRepository : Repository<Memo>, IMemosRepository
    {
        private readonly HairbookContext _context;

        public MemosRepository(HairbookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Memo>> GetMemosAsync(int index, int count, Expression<Func<Memo, bool>> predicate = null, Expression<Func<Memo, object>> orderBy = null, bool isReadonly = true)
        {
            IQueryable<Memo> result = _context.Memos
                                            .Include(x => x.Salon)
                                            .Include(x => x.Evaluations)
                                            .Include(x => x.Tags)
                                            .Include(x => x.Uploads);

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

        public async void AddMemo(Memo memo)
        {
            var model = await _context.Memos.AddAsync(memo);

            if (memo.Tags.Any())
            {
                foreach (var tag in memo.Tags)
                    tag.MemoId = model.Entity.MemoId;

                await _context.MemoTags.AddRangeAsync(memo.Tags);
            }
        }

        public void UpdateMemo(Memo memo)
        {
            var model = _context.Memos.Update(memo);

            if (memo.Tags.Any())
            {
                var updateTags = memo.Tags.Where(x => x.MemoTagId != 0).ToList();
                if (updateTags.Any())
                    _context.MemoTags.UpdateRange(updateTags);

                var newTags = memo.Tags.Where(x => x.MemoTagId == 0).ToList();
                foreach (var tag in newTags)
                    tag.MemoId = model.Entity.MemoId;
                if (newTags.Any())
                    _context.MemoTags.AddRange(newTags);
            }
        }

        public void DeleteMemo(Memo memo)
        {
            if (memo.Tags.Any())
                _context.MemoTags.RemoveRange(memo.Tags);

            if (memo.Evaluations.Any())
                _context.MemoEvaluations.RemoveRange(memo.Evaluations);

            if (memo.Uploads.Any())
                _context.MemoUploads.RemoveRange(memo.Uploads);

            _context.Memos.Remove(memo);
        }
    }
}
