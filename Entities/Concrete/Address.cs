﻿using System;
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

        public virtual Customer Customer { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
