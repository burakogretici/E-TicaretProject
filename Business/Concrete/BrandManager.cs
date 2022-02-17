using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        public IDataResult<BrandDto> Add(BrandDto model)
        {
            var mapper = _mapper.Map<Brand>(model);
            _brandDal.Add(mapper);
            return new SuccessDataResult<BrandDto>(model, Messages.BrandAdded);


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

        public async Task<IDataResult<List<BrandDto>>> GetAllAsync()
        {
            var result = await _brandDal.GetAllAsync();
            var mapper = _mapper.Map<List<BrandDto>>(result);

            return new SuccessDataResult<List<BrandDto>>(mapper, Messages.BrandListed);
        }

        public async Task<IDataResult<BrandDto>> GetByIdAsync(long brandId)
        {
            var result =  await _brandDal.GetAsync(br => br.Id == brandId);
            var mapper = _mapper.Map<BrandDto>(result);
            return new SuccessDataResult<BrandDto>(mapper);
        }
        
        //private IResult BrandNameAlreadyExists(string brandName)
        //{
        //    var result =  _brandDal.GetAllAsync(b => b.Name == brandName).Any();
        //    if (result == true)
        //    {
        //        return new ErrorResult(Messages.BrandNameAlreadyExists);
        //    }

        //    return new SuccessResult();
        //}


    }
}
