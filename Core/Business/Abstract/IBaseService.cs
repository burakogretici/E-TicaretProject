using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Abstract
{
    public interface IBaseService<T> 
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);

        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);

    }
}
