using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Categories;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryDto model)
        {
            var mapper = _mapper.Map<Category>(model);
            await _categoryDal.AddAsync(mapper);
            return new SuccessDataResult<CategoryDto>(model,Messages.CategoryAdded);
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            await _categoryDal.UpdateAsync(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
            await _categoryDal.DeleteAsync(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [CacheAspect]
        public async Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            var result = await _categoryDal.GetAllAsync();
            var mapper = _mapper.Map<List<CategoryDto>>(result);
            return new SuccessDataResult<IEnumerable<CategoryDto>>(mapper,Messages.CategoryListed);
        }
        

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id)
        {
            var result = await _categoryDal.GetAsync(c => c.Id == id);
            var mapper = _mapper.Map<CategoryDto>(result);
            return new SuccessDataResult<CategoryDto>(mapper);
        }


    }
}

