using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISupplierService 
    {
        IResult Add(Supplier supplier);
        IResult Update(Supplier supplier);
        IResult Delete(Supplier supplier);

        Task<IDataResult<IEnumerable<Supplier>>> GetAllAsync();
        Task<IDataResult<Supplier>> GetByIdAsync(Guid id);
    }
}
