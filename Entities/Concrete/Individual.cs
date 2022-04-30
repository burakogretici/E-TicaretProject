using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Individual : BaseEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
