using AutoMapper;
using Business.Services.Authorizations;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                return response;
            }
        }

    }
}
