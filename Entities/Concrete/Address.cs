using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Address : BaseEntity<Guid>
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }

        public virtual User User { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
