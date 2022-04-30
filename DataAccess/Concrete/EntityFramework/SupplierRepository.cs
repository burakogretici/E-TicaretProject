using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class SupplierRepository : EfEntityRepositoryBase<Supplier, EticaretContext>,ISupplierRepository
    {
        public SupplierRepository(EticaretContext context) : base(context)
        {
        }
    }
}
