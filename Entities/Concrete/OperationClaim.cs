using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class OperationClaim : BaseEntity<Guid>
    {
        public OperationClaim()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
