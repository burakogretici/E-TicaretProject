using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Brands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Brands
{
    public interface IBrandService
    {
        Task<IDataResult<BrandDto>> AddAsync(BrandDto brand);
        Task<IResult> UpdateAsync(BrandDto brand);
        Task<IResult> DeleteAsync(BrandDto brand);

        Task<IDataResult<List<BrandDto>>> GetAllAsync();
        Task<PaginatedResult<BrandDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);

        Task<IDataResult<BrandDto>> GetByIdAsync(Guid id);
    }
}
