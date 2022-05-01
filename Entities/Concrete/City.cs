using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class City : BaseEntity<Guid>
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
