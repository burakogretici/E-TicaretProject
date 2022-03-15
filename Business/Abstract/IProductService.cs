using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Products;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> AddAsync(ProductDto product);
        Task<IResult> UpdateAsync(Product product);
        Task<IResult> DeleteAsync(Product product);

        Task<IDataResult<IEnumerable<ProductDto>>> GetAllAsync();
        Task<IDataResult<ProductDto>> GetByIdAsync(Guid id);

        Task<IDataResult<IEnumerable<ProductDto>>> GetAllByCategoryIdAsync(Guid categoryId);
        Task<IDataResult<IEnumerable<ProductDto>>> GetByUnitPriceAsync(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

    }
}
