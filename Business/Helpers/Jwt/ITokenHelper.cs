using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Helpers.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IEnumerable<OperationClaim> operationClaims);
    }
}
