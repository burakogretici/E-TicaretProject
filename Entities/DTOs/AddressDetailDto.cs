using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class AddressDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public string AddressDetail { get; set; }


    }
}
