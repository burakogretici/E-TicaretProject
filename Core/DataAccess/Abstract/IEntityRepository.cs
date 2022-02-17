using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    
}
