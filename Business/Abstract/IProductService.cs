using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<ProductDto> Add(ProductDto product);
        IResult Update(Product product);
        IResult Delete(Product product);

        Task<IDataResult<IEnumerable<ProductDto>>> GetAllAsync();
        Task<IDataResult<ProductDto>> GetByIdAsync(int id);

        Task<IDataResult<IEnumerable<ProductDto>>> GetAllByCategoryIdAsync(int categoryId);
        Task<IDataResult<IEnumerable<ProductDto>>> GetByUnitPriceAsync(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

    }
}
