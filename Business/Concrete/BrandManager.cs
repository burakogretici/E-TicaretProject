using System;
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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(BrandNameAlreadyExists(brand.Name));
            if (result == null)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }

            return result;
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(long brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(br => br.Id == brandId));
        }

        private IResult BrandNameAlreadyExists(string brandName)
        {
            var result = _brandDal.GetAll(b => b.Name == brandName).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExists);
            }

            return new SuccessResult();
        }

      
    }
}
