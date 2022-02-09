using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Supplier : /*User*/IEntity
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }

    }
}
