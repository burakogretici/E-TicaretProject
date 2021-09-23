using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.AddressDal;
using Entities.Concrete;

using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework.EfAddressDal
{ 
    public class EfAddressDal : EfEntityRepositoryBase<Address, EticaretContext>, IAddressDal
    {
        public List<AddressDetailDto> GetAddressDetails()
        {
            using (EticaretContext context = new EticaretContext())
            {
                var result = from a in context.Addresses
                    join user in context.Users on a.UserId equals user.Id
                    join cou in context.Countries on a.CountryId equals cou.Id
                    join city in context.Cities on a.CityId equals city.Id
                    select new AddressDetailDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        CountryName = cou.Name,
                        CityName = city.Name,
                        PostalCode = a.PostalCode,
                        AddressDetail = a.AddressDetail
                    };
                return result.ToList();
            }
        }
    }
}
