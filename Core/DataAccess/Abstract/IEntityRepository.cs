using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Core.Entities.Concrete;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);

      
    }

    
}
