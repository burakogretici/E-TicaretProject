using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
     public class CityRepository : EfEntityRepositoryBase<City, EticaretContext>, ICityRepository
    {
        public CityRepository(EticaretContext context) : base(context)
        {

        }
    }
}
