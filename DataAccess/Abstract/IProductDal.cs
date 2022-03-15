using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Products;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>, IEntityAsyncRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();

    }
}
