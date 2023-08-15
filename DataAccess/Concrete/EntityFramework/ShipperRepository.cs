using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class ShipperRepository : EfEntityRepositoryBase<Shipper, EticaretContext>, IShipperRepository
    {
        public ShipperRepository(EticaretContext context) : base(context)
        {
        }
    }
}
