using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Categories;

namespace Business.Abstract
{
    public interface ICategoryService 
    {
        Task<IDataResult<CategoryDto>> AddAsync(CategoryDto category);
        Task<IResult> UpdateAsync(Category category);
        Task<IResult> DeleteAsync(Category category);

        Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync();
        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id);
    }
}
