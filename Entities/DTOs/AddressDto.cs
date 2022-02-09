using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class AddressDto : IDto
    {
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
    }
}
