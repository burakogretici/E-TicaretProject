using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Brands;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        private readonly BrandRules _brandRules;
        public BrandManager(IBrandDal brandDal, IMapper mapper, BrandRules brandRules)
        {
            _brandDal = brandDal;
            _mapper = mapper;
            _brandRules = brandRules;
        }

        public async Task<IDataResult<BrandDto>> AddAsync(BrandDto model)
        {
            IResult result =BusinessRules.Run(_brandRules.BrandNameAlreadyExists(model.Name));
            if (result.Success)
            {
                var mapper = _mapper.Map<Brand>(model);
                await _brandDal.AddAsync(mapper);
                return new SuccessDataResult<BrandDto>(model, Messages.BrandAdded);
            }

            return new ErrorDataResult<BrandDto>(result.Message);

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

        public async Task<IDataResult<IEnumerable<BrandDto>>> GetAllAsync()
        {
            var result = await _brandDal.GetAllAsync();
            var mapper = _mapper.Map<List<BrandDto>>(result);

            return new SuccessDataResult<IEnumerable<BrandDto>>(mapper, Messages.BrandListed);
        }

        public async Task<IDataResult<BrandDto>> GetByIdAsync(Guid brandId)
        {
            var result =  await _brandDal.GetAsync(br => br.Id == brandId);
            var mapper = _mapper.Map<BrandDto>(result);
            return new SuccessDataResult<BrandDto>(mapper);
        }
        
       

    }
}
