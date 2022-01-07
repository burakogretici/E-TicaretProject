﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public IResult Add(Supplier supplier)
        {
            IResult result = BusinessRules.Run(SupplierNameAlreadyExists(supplier.SupplierName));
            if (result != null)
            {
                return result;
            }
            _supplierDal.Add(supplier);
            return new SuccessResult(Messages.SupplierAdded);
        }

        public IResult Update(Supplier supplier)
        {
           _supplierDal.Update(supplier);
           return new SuccessResult(Messages.SupplierUpdated);
        }

        public IResult Delete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
            return new SuccessResult(Messages.SupplierDeleted);
        }

        public IDataResult<List<Supplier>> GetAll()
        {

            return new SuccessDataResult<List<Supplier>>(_supplierDal.GetAll(),Messages.SuppliersListed);
        }

        public IDataResult<Supplier> GetById(long supplierId)
        {
            return new SuccessDataResult<Supplier>(_supplierDal.Get(s=>s.Id==supplierId));
        }

        private IResult SupplierNameAlreadyExists(string companyName)
        {
            var result = _supplierDal.GetAll(s => s.SupplierName == companyName);
            if (result == null)
            {
                return new ErrorResult(Messages.SupplierNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}