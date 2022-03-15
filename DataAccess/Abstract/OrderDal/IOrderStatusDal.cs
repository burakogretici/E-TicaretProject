using Core.DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Abstract.OrderDal
{
    public interface IOrderStatusDal : IEntityRepository<OrderStatus>, IEntityAsyncRepository<OrderStatus>
    {
    }
}
