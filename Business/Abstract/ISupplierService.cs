using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISupplierService 
    {
        Task<IResult> AddAsync(Supplier supplier);
        Task<IResult> UpdateAsync(Supplier supplier);
        Task<IResult> DeleteAsync(Supplier supplier);

        Task<IDataResult<IEnumerable<Supplier>>> GetAllAsync();
        Task<IDataResult<Supplier>> GetByIdAsync(Guid id);
    }
}
