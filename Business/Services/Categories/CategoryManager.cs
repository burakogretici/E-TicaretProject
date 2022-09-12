using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Categories;


namespace Business.Services.Categories
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryRules _categoryRules;

        public CategoryManager(IMapper mapper, IUnitOfWork unitOfWork, CategoryRules categoryRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryRules = categoryRules;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryDto model)
        {
            IResult result = BusinessRules.Run(await _categoryRules.CategoryNameAlreadyExists(model.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<Category>(model);
                await _unitOfWork.CategoryRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<CategoryDto>(model, Messages.BrandAdded);
            }
            return new ErrorDataResult<CategoryDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(CategoryDto categoryDto)
        {

            var category = await GetByIdAsync(categoryDto.Id);
            if (category.Data != null)
            {
                IResult result = BusinessRules.Run(await _categoryRules.CategoryNameAlreadyExists(categoryDto.Name));
                if (result == null)
                {
                    category.Data.Name = categoryDto.Name;
                    var mapper = _mapper.Map<Category>(category.Data);
                    await _unitOfWork.CategoryRepository.UpdateAsync(mapper);
                    await _unitOfWork.Commit();
                    return new SuccessResult(Messages.CategoryUpdated);
                }
                else
                {
                    return new ErrorResult(Messages.CategoryNameAlreadyExists);
                }

            }
            else
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
        }

        public async Task<IResult> DeleteAsync(CategoryDto categoryDto)
        {
            var category = await GetByIdAsync(categoryDto.Id);
            if (category.Data != null)
            {
                var mapper = _mapper.Map<Category>(category.Data);
                await _unitOfWork.CategoryRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandDeleted);
            }
            else
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
        }

        [CacheAspect(50)]
        public async Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.CategoryRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<CategoryDto>>(result, Messages.CategoryListed);
        }

        [CacheAspect(50)]
        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid categoryId)
        {
            var result = await _unitOfWork.CategoryRepository.GetAsync(br => br.Id == categoryId);
            var mapper = _mapper.Map<CategoryDto>(result);
            return new SuccessDataResult<CategoryDto>(mapper);
        }
    }
}
