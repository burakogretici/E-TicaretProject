using Business.Constants;
using Business.Rules;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Core.Utilities.Results.Paging;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;

namespace Business.Services.Brands
{
    public class BrandManager : ServiceBase, IBrandService
    {
        private readonly BrandRules _brandRules;
        public BrandManager(IServiceProvider serviceProvider, BrandRules brandRules) : base(serviceProvider)
        {
            _brandRules = brandRules;
        }

        [SecuredOperation("Brand.Add,Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public async Task<IDataResult<BrandDto>> AddAsync(BrandDto model)
        {
            await _brandRules.BrandNameAlreadyExists(model.Name);

            var mapper = _mapper.Map<Brand>(model);
            await _unitOfWork.BrandRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<BrandDto>(model, Messages.BrandAdded);
     
        }
        [SecuredOperation("Brand.Update,Admin")]
        [LogAspect(typeof(FileLogger))]
        public async Task<IResult> UpdateAsync(BrandDto brandDto)
        {
            var oldEntity = await GetByIdAsync(brandDto.Id);

            await _brandRules.BrandNameAlreadyExists(brandDto.Name);
            brandDto.CreatedDate = oldEntity.Data.CreatedDate;

            var brand = _mapper.Map<Brand>(brandDto);
            await _unitOfWork.BrandRepository.UpdateAsync(brand);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.BrandUpdated);

        }
        [SecuredOperation("Brand.Delete,Admin")]
        public async Task<IResult> DeleteAsync(BrandDto brandDto)
        {
            var brand = await GetByIdAsync(brandDto.Id);

            var mapper = _mapper.Map<Brand>(brand.Data);
            await _unitOfWork.BrandRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.BrandDeleted);

        }
        //[SecuredOperation("Brand.List,Admin")]
        public async Task<IDataResult<List<BrandDto>>> GetAllAsync()
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
            var mapper = _mapper.Map<List<BrandDto>>(result);

            return new SuccessDataResult<List<BrandDto>>(mapper, Messages.BrandListed);
        }
        [SecuredOperation("Brand.Get,Admin")]
        public async Task<IDataResult<BrandDto>> GetByIdAsync(Guid brandId)
        {
            var result = await _unitOfWork.BrandRepository.GetAsync(br => br.Id == brandId);
            if (result == null) throw new BusinessException(Messages.BrandNotFound);

            var mapper = _mapper.Map<BrandDto>(result);
            return new SuccessDataResult<BrandDto>(mapper);
        }

        //[SecuredOperation("Brand.List,Admin")]
        public async Task<PaginatedResult<BrandDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var brands = await _unitOfWork.BrandRepository.GetListForTableSearch(tableGlobalFilter);
            var mapped = _mapper.Map<PaginatedResult<BrandDto>>(brands);
            return mapped;
        }
    }
}
