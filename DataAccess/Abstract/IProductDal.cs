using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Products;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>, IEntityAsyncRepository<Product>
    {
        Task<List<ProductDetailDto>> GetProductDetails();

    }
}
