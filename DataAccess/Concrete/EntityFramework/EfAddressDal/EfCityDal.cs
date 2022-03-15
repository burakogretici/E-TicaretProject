using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.AddressDal;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework.EfAddressDal
{
     public class EfCityDal : EfEntityRepositoryBase<City, EticaretContext>, ICityDal
    {
        public EfCityDal(EticaretContext context) : base(context)
        {
        }
    }
}
