using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public async Task<IResult> AddAsync(Supplier supplier)
        {
            IResult result = BusinessRules.Run(/*SupplierNameAlreadyExists(supplier.SupplierName)*/);
            if (result != null)
            {
                return result;
            }
            await _supplierDal.AddAsync(supplier);
            return new SuccessResult(Messages.SupplierAdded);
        }

        public async Task<IResult> UpdateAsync(Supplier supplier)
        { 
            await _supplierDal.UpdateAsync(supplier);
           return new SuccessResult(Messages.SupplierUpdated);
        }

        public async Task<IResult> DeleteAsync(Supplier supplier)
        {
            await _supplierDal.DeleteAsync(supplier);
            return new SuccessResult(Messages.SupplierDeleted);
        }

        public async Task<IDataResult<IEnumerable<Supplier>>> GetAllAsync()
        {

            return new SuccessDataResult<IEnumerable<Supplier>>(await _supplierDal.GetAllAsync(),Messages.SuppliersListed);
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
