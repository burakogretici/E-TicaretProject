using AutoMapper;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.BusinessAspects;

namespace Business.Services.Brands
{
    public class BrandManager : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BrandRules _brandRules;
        public BrandManager(IMapper mapper, IUnitOfWork unitOfWork, BrandRules brandRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _brandRules = brandRules;
        }


        public async Task<IDataResult<BrandDto>> AddAsync(BrandDto model)
        {
            IResult result = BusinessRules.Run(await _brandRules.BrandNameAlreadyExists(model.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<Brand>(model);
                await _unitOfWork.BrandRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<BrandDto>(model, Messages.BrandAdded);
            }
            return new ErrorDataResult<BrandDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(BrandDto brandDto)
        {
            IResult result = BusinessRules.Run(await _brandRules.BrandNameAlreadyExists(brandDto.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<Brand>(brandDto);
                await _unitOfWork.BrandRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandUpdated);
            }

            return result;

        }

        public async Task<IResult> DeleteAsync(BrandDto brandDto)
        {
            var brand = await GetByIdAsync(brandDto.Id);
            if (brand.Data != null)
            {
                var mapper = _mapper.Map<Brand>(brand.Data);
                await _unitOfWork.BrandRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandDeleted);
            }

            return brand;

        }

        //[SecuredOperation("Admin")]
        public async Task<IDataResult<IEnumerable<BrandDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.BrandRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new BrandDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<BrandDto>>(result, Messages.BrandListed);
        }

        public async Task<IDataResult<BrandDto>> GetByIdAsync(Guid brandId)
        {
            var result = await _unitOfWork.BrandRepository.GetAsync(br => br.Id == brandId);
            if (result == null)
            {
                return new ErrorDataResult<BrandDto>(Messages.BrandNotFound);
            }
            var mapper = _mapper.Map<BrandDto>(result);
            return new SuccessDataResult<BrandDto>(mapper);
        }
    }
}
