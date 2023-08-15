using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Enums;
using Core.Extensions;
using Core.Utilities.Results.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityAsyncRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext Context { get; }
        int _sayac;
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        public DbSet<TEntity> Table => Context.Set<TEntity>();


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await Table.AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            var query = Query();

            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? expression = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> query = Table;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).ToListAsync();
            }
            else
            {
                return await query.Select(selector).ToListAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            var list = Query();

            if (includeEntities.Length > 0)
                list = list.IncludeMultiple(includeEntities);

            return expression == null
                ? await list.ToListAsync()
                : await list.Where(expression).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
            => await Table.AnyAsync(predicate);
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
            => await Table.CountAsync(predicate);

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            return Task.FromResult(entity);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return Task.FromResult(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;

            return Task.FromResult(entity);
        }
        private async Task AttachIfNot(TEntity entity)
        {
            var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);

            if (entry != null)
            {
                return;
            }

            Table.Attach(entity);
        }
        public async Task<PaginatedResult<TEntity>> GetListForPaging(int page, int pageSize, string propertyName, bool asc, Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            var list = Query();

            if (includeEntities.Length > 0)
                list = list.IncludeMultiple(includeEntities);

            if (expression != null)
                list = list.Where(expression).AsQueryable();
            list = asc ? list.AscOrDescOrder(ESort.ASC, propertyName) : list.AscOrDescOrder(ESort.DESC, propertyName);
            int totalCount = await list.CountAsync();

            var start = (page - 1) * pageSize;
            list = list.Skip(start).Take(pageSize);

            return new PaginatedResult<TEntity>(await list.ToListAsync(), page, pageSize, totalCount);
        }

        public async Task<PaginatedResult<TEntity>> GetListForTableSearch(TableGlobalFilter globalFilter, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            var list = Query();
            var start = (globalFilter.First - 1) * globalFilter.Rows;

            if (includeEntities.Length > 0)
                list = list.IncludeMultiple(includeEntities);

            var parameterOfExpression = Expression.Parameter(typeof(TEntity), "x");

            if (globalFilter.Filters != null && globalFilter.Filters.Count > 0)
            {
                Expression globalFilterExpression = null;

                foreach (var filter in globalFilter.Filters)
                {
                    var fieldParts = filter.Field.Split('.'); // Alanı nokta karakterine göre bölelim

                    Expression propertyExpression = parameterOfExpression; 

                    // Alanın her bir parçası için özelliği temsil eden ifadeleri oluşturalım
                    foreach (var fieldPart in fieldParts)
                    {
                        propertyExpression = Expression.PropertyOrField(propertyExpression, fieldPart);
                    }

                    if (TableGlobalFilterExtensions.Operators.TryGetValue(filter.Operator.ToLower(), out var operatorFunc))
                    {
                        var propertyType = propertyExpression.Type;
                        var searchedValueType = propertyType.IsNullable() ? Nullable.GetUnderlyingType(propertyType) : propertyType;

                        if (searchedValueType == typeof(DateTime) || searchedValueType == typeof(DateTime?))
                        {
                            var dateTimeFilterExpression = TableGlobalFilterExtensions.CreateDateTimeFilterExpression(propertyExpression, filter.SearchValue);

                            if (dateTimeFilterExpression != null)
                            {
                                if (globalFilterExpression == null)
                                    globalFilterExpression = dateTimeFilterExpression;
                                else
                                    globalFilterExpression = Expression.AndAlso(globalFilterExpression, dateTimeFilterExpression);

                                continue; 
                            }
                        }

                        var searchedValueExpression = Expression.Constant(Convert.ChangeType(filter.SearchValue, searchedValueType));

                        var operatorExpression = operatorFunc.Invoke(propertyExpression, searchedValueExpression);

                        if (globalFilterExpression == null)
                            globalFilterExpression = operatorExpression;
                        else
                            globalFilterExpression = Expression.AndAlso(globalFilterExpression, operatorExpression);
                    }
                }

                list = list.Where(Expression.Lambda<Func<TEntity, bool>>(globalFilterExpression, parameterOfExpression));
            }

            var totalCountForFilter = await list.CountAsync();

            var final = list.AscOrDescOrder(globalFilter.SortOrder == 1 ? ESort.ASC : ESort.DESC, globalFilter.SortField)
                             .Skip(start)
                             .Take(globalFilter.Rows);

            return new PaginatedResult<TEntity>(await final.ToListAsync(), globalFilter.First, globalFilter.Rows, totalCountForFilter);
        }

    

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }
    }
}
