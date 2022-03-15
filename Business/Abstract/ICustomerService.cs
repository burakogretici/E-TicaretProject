using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        Task<IResult> AddAsync(Customer customer);
        Task<IResult> UpdateAsync(Customer customer);
        Task<IResult> DeleteAsync(Customer customer);

        Task<IDataResult<IEnumerable<Customer>>> GetAllAsync();
        Task<IDataResult<Customer>> GetByIdAsync(Guid id);
    }
}
