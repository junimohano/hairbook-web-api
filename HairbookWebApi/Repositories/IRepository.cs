using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HairbookWebApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(bool isReadonly = true);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool isReadonly = true);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, bool isReadonly = true);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
