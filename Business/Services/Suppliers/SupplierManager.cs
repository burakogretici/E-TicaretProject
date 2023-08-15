using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Suppliers
{
    public class SupplierManager : ServiceBase, ISupplierService
    {
        public SupplierManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        } 

        public async Task<IResult> AddAsync(Supplier supplier)
        {
            IResult result = BusinessRules.Run(/*SupplierNameAlreadyExists(supplier.SupplierName)*/);
            if (result != null)
            {
                return result;
            }
            await _unitOfWork.SupplierRepository.AddAsync(supplier);
            return new SuccessResult(Messages.SupplierAdded);
        }

        public async Task<IResult> UpdateAsync(Supplier supplier)
        {
            await _unitOfWork.SupplierRepository.UpdateAsync(supplier);
            return new SuccessResult(Messages.SupplierUpdated);
        }

        public async Task<IResult> DeleteAsync(Supplier supplier)
        {
            await _unitOfWork.SupplierRepository.DeleteAsync(supplier);
            return new SuccessResult(Messages.SupplierDeleted);
        }

        public async Task<IDataResult<IEnumerable<Supplier>>> GetAllAsync()
        {

            return new SuccessDataResult<IEnumerable<Supplier>>(await _unitOfWork.SupplierRepository.GetAllAsync<Supplier>(null), Messages.SuppliersListed);
        }

        public async Task<IDataResult<Supplier>> GetByIdAsync(Guid id)
        {
            return null; /*new SuccessDataResult<Supplier>(_supplierDal.Get(s=>s.Id==id));*/
        }


        //private IResult SupplierNameAlreadyExists(string companyName)
        //{
        //    var result = _supplierDal.GetAll(s => s.SupplierName == companyName);
        //    if (result == null)
        //    {
        //        return new ErrorResult(Messages.SupplierNameAlreadyExists);
        //    }

        //    return new SuccessResult();
        //}
    }
}
