using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    //DÜZENLE
    public class Customer : /*User,*/ BaseEntity
    {
     
        public Guid AddressId { get; set; }

        public Address Address { get; set; }
    }
}
