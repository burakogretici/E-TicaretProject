using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Products
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> AddAsync(ProductDto productDto);
        Task<IResult> UpdateAsync(ProductDto productDto);
        Task<IResult> DeleteAsync(ProductDto productDto);

        Task<IDataResult<IEnumerable<ProductListDto>>> GetAllAsync();
        Task<PaginatedResult<ProductListDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);
        Task<IDataResult<ProductDto>> GetByIdAsync(Guid id);

        Task<IDataResult<IEnumerable<ProductDto>>> GetAllByCategoryIdAsync(Guid categoryId);
        Task<IDataResult<IEnumerable<ProductDto>>> GetByUnitPriceAsync(decimal min, decimal max);
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetails();

    }
}
