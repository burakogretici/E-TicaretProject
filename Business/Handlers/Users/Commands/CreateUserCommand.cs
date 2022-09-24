using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Users;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Users.Commands
{
    public class CreateUserCommand : IRequest<IResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
        {
            private readonly IMapper _mapper;
            private readonly IUserService _userService;

            public CreateUserCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserDto>(request);
                var user = await _userService.AddAsync(mapper);
                return user;
            }
        }
    }
}
