using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductImageRepository : IEntityAsyncRepository<ProductImage>
    {
    }
}
