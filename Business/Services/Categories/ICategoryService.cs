using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Dtos.Categories;

namespace Business.Services.Categories
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> AddAsync(CategoryDto category);
        Task<IResult> UpdateAsync(CategoryDto category);
        Task<IResult> DeleteAsync(CategoryDto category);

        Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync();
        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id);
    }
}