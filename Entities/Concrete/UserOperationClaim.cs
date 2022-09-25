using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }

        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
