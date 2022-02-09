using System.Collections.Generic;
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

        IDataResult<IEnumerable<ProductDto>> GetAll();
        IDataResult<ProductDto> GetById(int id);

        IDataResult<IEnumerable<ProductDto>> GetAllByCategoryId(int categoryId);
        IDataResult<IEnumerable<ProductDto>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

    }
}
