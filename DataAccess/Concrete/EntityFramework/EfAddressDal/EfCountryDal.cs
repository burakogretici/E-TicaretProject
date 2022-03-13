using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.AddressDal;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework.EfAddressDal
{
    public class EfCountryDal : EfEntityRepositoryBase<Country, EticaretContext>, ICountryDal
    {
    }
}
