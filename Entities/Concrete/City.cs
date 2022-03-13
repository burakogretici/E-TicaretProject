using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class City : BaseEntity
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
