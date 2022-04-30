using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CountryRepository : EfEntityRepositoryBase<Country, EticaretContext>, ICountryRepository
    {
        public CountryRepository(EticaretContext context) : base(context)
        {
        }
    }
}
