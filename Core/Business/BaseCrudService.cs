using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Business
{
    public interface BaseCrudService<T,Id>
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);

        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(Id id);
    }
}
