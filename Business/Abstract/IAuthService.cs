using Business.Helpers.Jwt;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Users;

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
