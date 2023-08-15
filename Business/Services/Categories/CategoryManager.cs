using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Categories;


namespace Business.Services.Categories
{
    public class CategoryManager : ServiceBase, ICategoryService
    {
        private readonly CategoryRules _categoryRules;

        public CategoryManager(IServiceProvider serviceProvider, CategoryRules categoryRules) : base(serviceProvider)
        {
            _categoryRules = categoryRules;
        }
        [SecuredOperation("Category.Add,Admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryDto model)
        {
            await _categoryRules.CategoryNameAlreadyExists(model.Name);

            var mapper = _mapper.Map<Category>(model);
            await _unitOfWork.CategoryRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<CategoryDto>(model, Messages.CategoryAdded);

        }
        [SecuredOperation("Category.Update,Admin")]
        public async Task<IResult> UpdateAsync(CategoryDto categoryDto)
        {
            var oldEntity = await GetByIdAsync(categoryDto.Id);
            await _categoryRules.CategoryNameAlreadyExists(categoryDto.Name);

            categoryDto.CreatedDate = oldEntity.Data.CreatedDate;
            var mapper = _mapper.Map<Category>(categoryDto);

            await _unitOfWork.CategoryRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.CategoryUpdated);

        }

        public async Task<IResult> DeleteAsync(CategoryDto categoryDto)
        {
            var category = await GetByIdAsync(categoryDto.Id);

            var mapper = _mapper.Map<Category>(category.Data);
            await _unitOfWork.CategoryRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.CategoryDeleted);

        }
        [SecuredOperation("Category.List,Admin")]
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

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid categoryId)
        {
            var result = await _unitOfWork.CategoryRepository.GetAsync(br => br.Id == categoryId);
            if (result == null) throw new BusinessException(Messages.CategoryNotFound);

            var mapper = _mapper.Map<CategoryDto>(result);
            return new SuccessDataResult<CategoryDto>(mapper);
        }

        public async Task<PaginatedResult<CategoryDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var categories = await _unitOfWork.CategoryRepository.GetListForTableSearch(tableGlobalFilter);
            var mapped = _mapper.Map<PaginatedResult<CategoryDto>>(categories);
            return mapped;
        }
    }
}
