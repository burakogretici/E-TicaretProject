using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        T? Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

      
    }

    
}
