using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Users;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Users.Queries
{
    public class GetUserQuery : IRequest<IDataResult<UserDto>>
    {
        public Guid Id { get; set; }

        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IDataResult<UserDto>>
        {
            private readonly IUserService _userService;

            public GetUserQueryHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<IDataResult<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _userService.GetByIdAsync(request.Id);
                return user;
            }
        }
    }
}
