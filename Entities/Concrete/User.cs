using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
