using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
            Baskets = new HashSet<Basket>();

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
