using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Supplier : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string SupplierName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }

    }
}
