using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Users;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Users.Queries
{
    public class GetUsersTableQuery : IRequest<PaginatedResult<UserDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }

        public class GetUsersQueryHandler : IRequestHandler<GetUsersTableQuery, PaginatedResult<UserDto>>
        {
            private readonly IUserService _userService;

            public GetUsersQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<PaginatedResult<UserDto>> Handle(GetUsersTableQuery request, CancellationToken cancellationToken)
            {
                var userList = await _userService.GetTableSearch(request.TableGlobalFilter);
                return userList;
            }
        }
    }
}
