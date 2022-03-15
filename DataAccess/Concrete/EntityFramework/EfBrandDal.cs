using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, EticaretContext>, IBrandDal
    {
        public EfBrandDal(EticaretContext context) : base(context)
        {
        }
    }
}
