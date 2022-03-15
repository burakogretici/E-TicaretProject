using Core.DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Abstract.OrderDal
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>, IEntityAsyncRepository<OrderDetail>
    {

    }
}
