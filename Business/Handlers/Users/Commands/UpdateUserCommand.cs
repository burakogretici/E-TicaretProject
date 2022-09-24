using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Users;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Users.Commands
{
    public class UpdateUserCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResult>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;
            public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserDto>(request);
                var user = await _userService.UpdateAsync(mapper);
                return user;

            }
        }
    }
}