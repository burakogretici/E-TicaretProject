using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Suppliers
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
