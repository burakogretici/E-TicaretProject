using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Services.Authorizations;
using Business.Services.Users;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Authorizations.Commands
{
    public class RegisterUserCommand : IRequest<IResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IResult>
        {
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

            public RegisterUserCommandHandler(IMapper mapper, IAuthService authService)
            {
                _mapper = mapper;
                _authService = authService;
            }


            public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserForRegister>(request);
                var response = await _authService.Register(mapper, request.Password);
                return response;
            }
        }
    }
}
