using AutoMapper;
using Business.Helpers.Jwt;
using Business.Services.Authorizations;
using Business.Services.Users;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Authorizations.Queries
{
    public class LoginUserQuery : IRequest<IDataResult<AccessToken>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, IDataResult<AccessToken>>
        {
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public LoginUserQueryHandler(IMapper mapper, IAuthService authService)
            {
                _mapper = mapper;
                _authService = authService;
               
            }

            public async Task<IDataResult<AccessToken>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserForLogin>(request);
                var response = await _authService.Login(mapper);
                if (response.Success)
                {
                    var result = await _authService.CreateAccessToken(response.Data);
                    if (result.Success)
                    {
                        return new SuccessDataResult<AccessToken>(result.Data);                   
                    }
                   
                }
                else
                {
                    return new ErrorDataResult<AccessToken>(response.Message);
                }
                return new SuccessDataResult<AccessToken>(response.Message);
            }
        }

    }
}
