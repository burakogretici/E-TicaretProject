using System;
using System.Collections.Generic;

namespace Entities.Dtos.UserOperationClaim
{
    public class UserOperationClaimDto : BaseDto
    {
        public Guid UserId { get; set; }
        public List<Guid> OperationClaimIds { get; set; } = new List<Guid>();

        public string UserName { get; set; }
        public List<string> OperationClaimNames { get; set; } = new List<string>();


    }
}
