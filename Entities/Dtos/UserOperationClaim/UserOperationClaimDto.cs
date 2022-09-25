using System;

namespace Entities.Dtos.UserOperationClaim
{
    public class UserOperationClaimDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
