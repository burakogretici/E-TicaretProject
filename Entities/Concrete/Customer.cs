using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    //DÜZENLE
    public class Customer : /*User,*/ IEntity
    {
        public int CustomerId { get; set; }
        public long AddressId { get; set; }
       

    }
}
