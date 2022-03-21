using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Address : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public ICollection<Order> Orders { get; set; }
        
    }
}
