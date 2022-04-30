using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;

namespace DataAccess.Abstract
{
    public interface IProductRepository : IEntityAsyncRepository<Product>
    {
        Task<List<ProductDetailDto>> GetProductDetails();

    }
}
