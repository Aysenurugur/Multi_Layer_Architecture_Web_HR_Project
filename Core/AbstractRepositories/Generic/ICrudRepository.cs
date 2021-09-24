using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.AbstractRepositories.Generic
{
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetByIDAsync(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void RemoveAsync(TEntity entity);
        void RemoveRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
    }
}
