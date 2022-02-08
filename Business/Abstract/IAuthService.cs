using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegister userForRegister,string password);
        IDataResult<User> Login(UserForLogin userForLogin);
        IResult UserExits(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
