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
    public class DeleteUserCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResult>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;
            public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserDto>(request);
                var user = await _userService.DeleteAsync(mapper);
                return user;

            }
        }
    }
}
