using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Queries
{
    public class GetUserOperationClaimQuery : IRequest<IDataResult<UserOperationClaimDto>>
    {
        public Guid Id { get; set; }

        public class GetUserOperationClaimQueryHandler : IRequestHandler<GetUserOperationClaimQuery, IDataResult<UserOperationClaimDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetUserOperationClaimQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<UserOperationClaimDto>> Handle(GetUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                //todo:bir daha incele
                var userOperationClaim = await _unitOfWork.UserOperationClaimRepository.GetAsync(a => a.UserId == request.Id);
                var userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);
                return new SuccessDataResult<UserOperationClaimDto>(userOperationClaimDto);
            }
        }
    }
}
