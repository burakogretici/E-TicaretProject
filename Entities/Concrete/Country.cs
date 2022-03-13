using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
