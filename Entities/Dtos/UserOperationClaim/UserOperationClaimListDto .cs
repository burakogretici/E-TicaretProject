using Entities.Concrete;
using Entities.Dtos.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserOperationClaim
{
    public class UserOperationClaimListDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public List<OperationClaimDto> OperationClaims { get; set; }



    }
}
