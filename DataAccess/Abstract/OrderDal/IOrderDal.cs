using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract.OrderDal
{
    public interface IOrderDal : IEntityRepository<Order>, IEntityAsyncRepository<Order>
    {
      

    }
}
