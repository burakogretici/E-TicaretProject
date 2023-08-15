using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.DataAccess.Abstract
{
    public interface IEntityAsyncRepository<TEntity> : IQuery<TEntity> where TEntity : IEntity
    {

        Task<PaginatedResult<TEntity>> GetListForTableSearch(TableGlobalFilter globalFilter, params Expression<Func<TEntity, object>>[] includeEntities);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null);

        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector = null,
            Expression<Func<TEntity, bool>>? expression= null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeEntities);

        Task<PaginatedResult<TEntity>> GetListForPaging(int page,int pageSize, string propertyName, bool asc, Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeEntities);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate); 
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);      
    }
}
