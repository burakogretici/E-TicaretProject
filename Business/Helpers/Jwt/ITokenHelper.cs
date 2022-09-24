using System.Collections.Generic;
using Entities.Concrete;
using Entities.Dtos.Users;

namespace Business.Helpers.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserDto userDto, IEnumerable<OperationClaim> operationClaims);
    }
}
