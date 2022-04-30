using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.OperationClaims;
using MediatR;

namespace Business.Handlers.OperationClaims.Queries
{
    public class GetOperationClaimQuery : IRequest<IDataResult<OperationClaimDto>>
    {
        public Guid Id { get; set; }

        public class GetOperationClaimQueryHandler : IRequestHandler<GetOperationClaimQuery, IDataResult<OperationClaimDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetOperationClaimQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<OperationClaimDto>> Handle(GetOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var operationClaim = await _unitOfWork.OperationClaimRepository.GetAsync(a => a.Id == request.Id);
                var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);
                return new SuccessDataResult<OperationClaimDto>(operationClaimDto);
            }
        }
    }
}
