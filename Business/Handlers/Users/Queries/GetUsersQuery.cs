using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.Users.Queries
{
    public class GetUsersQuery : IRequest<IDataResult<IEnumerable<UserDto>>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IDataResult<IEnumerable<UserDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetUsersQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<UserDto>>> Handle(GetUsersQuery request,
                CancellationToken cancellationToken)
            {
                var userList = await _unitOfWork.UserRepository.GetAllAsync(
                    selector: x => new UserDto
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        IsActive = x.IsActive
                    },
                    expression: x => x.IsActive == true);

                return new SuccessDataResult<IEnumerable<UserDto>>(userList);
            }
        }
    }
}
