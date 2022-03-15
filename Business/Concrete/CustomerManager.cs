using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task<IResult> AddAsync(Customer customer)
        {
            await _customerDal.AddAsync(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public async Task<IResult> UpdateAsync(Customer customer)
        {
            await _customerDal.UpdateAsync(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public async Task<IResult> DeleteAsync(Customer customer)
        {
            await _customerDal.DeleteAsync(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public async Task<IDataResult<IEnumerable<Customer>>> GetAllAsync()
        {

            return new SuccessDataResult<IEnumerable<Customer>>(await _customerDal.GetAllAsync(),
                Messages.CustomersListed);

        }

        public async Task<IDataResult<Customer>> GetByIdAsync(Guid customerId)
        {
            return null;
            //return new SuccessDataResult<Customer>(await _customerDal.GetAsync(c => c.Id == customerId));
        }
    }
}
