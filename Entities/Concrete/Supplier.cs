using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Supplier : /*User*/BaseEntity
    {
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
