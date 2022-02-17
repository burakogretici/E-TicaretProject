using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);

        Task<IDataResult<IEnumerable<Customer>>> GetAllAsync();
        Task<IDataResult<Customer>> GetByIdAsync(int id);
    }
}
