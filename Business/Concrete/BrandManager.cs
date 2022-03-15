using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Brands;

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

        public async Task<IDataResult<BrandDto>> AddAsync(BrandDto model)
        {
            var mapper = _mapper.Map<Brand>(model);
            await _brandDal.AddAsync(mapper);
            return new SuccessDataResult<BrandDto>(model, Messages.BrandAdded);


        }

        public async Task<IResult> UpdateAsync(Brand brand)
        {
            await _brandDal.UpdateAsync(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public async Task<IResult> DeleteAsync(Brand brand)
        {
            await _brandDal.DeleteAsync(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public async Task<IDataResult<List<BrandDto>>> GetAllAsync()
        {
            var result = await _brandDal.GetAllAsync();
            var mapper = _mapper.Map<List<BrandDto>>(result);

            return new SuccessDataResult<List<BrandDto>>(mapper, Messages.BrandListed);
        }

        public async Task<IDataResult<BrandDto>> GetByIdAsync(Guid brandId)
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
