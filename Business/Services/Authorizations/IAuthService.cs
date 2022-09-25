using Business.Helpers.Jwt;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using System.Threading.Tasks;

namespace Business.Services.Authorizations
{
    public interface IAuthService
    {
        Task<IDataResult<UserDto>> Register(UserForRegister userForRegister, string password);
        Task<IDataResult<UserDto>> Login(UserForLogin userForLogin);
        IResult UserExits(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(UserDto userDto);

    }
}
