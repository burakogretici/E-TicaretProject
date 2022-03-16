using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.AddressDal;
using Entities.Concrete;
using Entities.DTOs.Addresses;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EfAddressDal
{
    public class EfAddressDal : EfEntityRepositoryBase<Address, EticaretContext>, IAddressDal
    {
        public EfAddressDal(EticaretContext context) : base(context)
        {
        }
        public async Task<List<AddressDetailDto>> GetAddressDetails()
        {
            var list = await (from a in Context.Addresses
                                  join user in Context.Users on a.UserId equals user.Id
                                  join cou in Context.Countries on a.CountryId equals cou.Id
                                  join city in Context.Cities on a.CityId equals city.Id

                                  select new AddressDetailDto
                                  {
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      CountryName = cou.Name,
                                      CityName = city.Name,
                                      PostalCode = a.PostalCode,
                                      AddressDetail = a.AddressDetail
                                  }).ToListAsync();
            return list;
        }
    }

}
