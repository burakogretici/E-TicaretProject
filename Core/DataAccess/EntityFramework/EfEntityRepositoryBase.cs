using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityAsyncRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext Context { get; }
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        public DbSet<TEntity> Table => Context.Set<TEntity>();


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await Table.FirstOrDefaultAsync(predicate);

        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector , Expression<Func<TEntity, bool>>? expression=null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
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
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
            => await Table.AnyAsync(predicate);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
            => await Table.CountAsync(predicate);

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

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Deleted;          
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
    }
}
