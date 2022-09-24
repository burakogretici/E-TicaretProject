using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Helpers.Jwt;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Authorizations.Queries
{
    public class LoginUserQuery : IRequest<IDataResult<AccessToken>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, IDataResult<AccessToken>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private ITokenHelper _tokenHelper;

            public LoginUserQueryHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<IDataResult<AccessToken>> Handle(LoginUserQuery request,
                CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.Email == request.Email && u.IsActive);

                if (user == null)
                {
                    return new ErrorDataResult<AccessToken>(Messages.UserNotFound);
                }

                if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash))
                {
                    return new ErrorDataResult<AccessToken>(Messages.PasswordError);
                }

                var claims = await _userRepository.GetClaims(user);

                var userDto = _mapper.Map<UserDto>(user);
                var accessToken = _tokenHelper.CreateToken(userDto, claims);

                return new SuccessDataResult<AccessToken>(accessToken, Messages.SuccessfulLogin);
            }
        }
    }
}