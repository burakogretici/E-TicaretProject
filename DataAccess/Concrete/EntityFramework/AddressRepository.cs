using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.Addresses;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AddressRepository : EfEntityRepositoryBase<Address, EticaretContext>, IAddressRepository
    {
        public AddressRepository(EticaretContext context) : base(context)
        {
        }
        public async Task<List<AddressDetailDto>> GetAddressDetails()
        {
            var list = await (from a in Context.Addresses
                                  join u in Context.Users on a.UserId equals u.Id
                                  join cou in Context.Countries on a.CountryId equals cou.Id
                                  join city in Context.Cities on a.CityId equals city.Id

                                  select new AddressDetailDto
                                  {
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      CountryName = cou.Name,
                                      CityName = city.Name,
                                      PostalCode = a.PostalCode,
                                      AddressDetail = a.AddressDetail
                                  }).ToListAsync();
            return list;
        }
    }

}
