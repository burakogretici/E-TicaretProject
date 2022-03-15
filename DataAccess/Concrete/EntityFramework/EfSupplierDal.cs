using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSupplierDal : EfEntityRepositoryBase<Supplier, EticaretContext>,ISupplierDal
    {
        public EfSupplierDal(EticaretContext context) : base(context)
        {
        }
    }
}
