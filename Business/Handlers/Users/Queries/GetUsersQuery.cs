using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Users;
using Core.Utilities.Results;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Users.Queries
{
    public class GetUsersQuery : IRequest<IDataResult<IEnumerable<UserDto>>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IDataResult<IEnumerable<UserDto>>>
        {
            private readonly IUserService _userService;

            public GetUsersQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<IDataResult<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var userList = await _userService.GetAllAsync();
                return userList;
            }
        }
    }
}
