using AutoMapper;
using Business.Helpers.Jwt;
using Business.Services.Authorizations;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Authorizations.Commands
{
    public class LoginUserCommand : IRequest<IResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IResult>
        {
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public LoginUserCommandHandler(IMapper mapper, IAuthService authService)
            {
                _mapper = mapper;
                _authService = authService;
            }


            public async Task<IResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserForLogin>(request);
                var response = await _authService.Login(mapper);
                if (!response.Success)
                {
                    return response;
                }
                var result = await _authService.CreateAccessToken(response.Data);
                if (result.Success)
                {
                    return new SuccessDataResult<AccessToken>(result.Data);
                }

                return response;
            }
        }

    }
}
