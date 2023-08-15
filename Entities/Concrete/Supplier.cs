using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Supplier : BaseEntity<Guid>
    {
        //public Supplier()
        //{
        //    Products = new HashSet<Product>();
        //}
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
        public virtual User User { get; set; }

    }
}
