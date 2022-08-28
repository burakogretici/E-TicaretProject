using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.DataAccess.Abstract
{
    public interface IEntityAsyncRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? expression= null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate); 
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);      
    }
}
