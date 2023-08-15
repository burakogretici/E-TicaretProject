using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Brands;
using Entities.Dtos.Categories;

namespace Business.Services.Categories
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> AddAsync(CategoryDto category);
        Task<IResult> UpdateAsync(CategoryDto category);
        Task<IResult> DeleteAsync(CategoryDto category);

        Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync();
        Task<PaginatedResult<CategoryDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);

        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id);
    }
}