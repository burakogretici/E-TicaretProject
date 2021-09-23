using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.AddressDal;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework.EfAddressDal
{
     public class EfCityDal : EfEntityRepositoryBase<City, EticaretContext>, ICityDal
    {
    }
}
