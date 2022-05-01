using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Country : BaseEntity<Guid>
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
