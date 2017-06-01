using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HairbookWebApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entity;

        public Repository(DbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<T> GetAsync(int id) 
            => await _entity.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync(bool isReadonly = true)
            => isReadonly ? await _entity.AsNoTracking().ToListAsync() : await _entity.ToListAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool isReadonly = true)
            => isReadonly ? await _entity.AsNoTracking().Where(predicate).ToListAsync() : await _entity.Where(predicate).ToListAsync();

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, bool isReadonly = true)
            => isReadonly ? await _entity.AsNoTracking().SingleOrDefaultAsync(predicate) : await _entity.SingleOrDefaultAsync(predicate);

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await _entity.AsNoTracking().AnyAsync(predicate);


        public async void Add(T entity) 
            => await _entity.AddAsync(entity);

        public async void AddRange(IEnumerable<T> entities)
            => await _entity.AddRangeAsync(entities);


        public void Update(T entity)
            => _context.Entry(entity).State = EntityState.Modified;

        public void UpdateRange(IEnumerable<T> entities)
            => _context.Entry(entities).State = EntityState.Modified;
        //=> _entity.UpdateRange(entities);


        public void Delete(T entity) 
            => _entity.Remove(entity);

        public void DeleteRange(IEnumerable<T> entities) 
            => _entity.RemoveRange(entities);

    }
}
