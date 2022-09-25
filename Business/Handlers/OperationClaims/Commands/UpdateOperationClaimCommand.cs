using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.OperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.OperationClaims;
using MediatR;

namespace Business.Handlers.OperationClaims.Commands
{
    public class UpdateOperationClaimCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, IResult>
        {
            private readonly IOperationClaimService _operationClaimService;
            private readonly IMapper _mapper;
            public UpdateOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper)
            {
                _operationClaimService = operationClaimService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<OperationClaimDto>(request);
                var operationClaim = await _operationClaimService.UpdateAsync(mapper);
                return operationClaim;

            }
        }
    }
}

