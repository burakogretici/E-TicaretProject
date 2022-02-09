using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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
        public IDataResult<CategoryDto> Add(CategoryDto model)
        {
            var mapper = _mapper.Map<Category>(model);
            _categoryDal.Add(mapper);
            return new SuccessDataResult<CategoryDto>(model,Messages.CategoryAdded);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public  IDataResult<IEnumerable<CategoryDto>> GetAll()
        {
            var result =  _categoryDal.GetAll();
            var mapper = _mapper.Map<List<CategoryDto>>(result);
            return new SuccessDataResult<IEnumerable<CategoryDto>>(mapper,Messages.CategoryListed);
        }
        

        public IDataResult<CategoryDto> GetById(int id)
        {
            var result = _categoryDal.Get(c => c.Id == id);
            var mapper = _mapper.Map<CategoryDto>(result);
            return new SuccessDataResult<CategoryDto>(mapper);
        }


    }
}

