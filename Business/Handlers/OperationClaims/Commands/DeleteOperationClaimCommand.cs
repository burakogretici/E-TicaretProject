using Core.Utilities.Results;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using Business.Services.OperationClaims;
using Entities.Dtos.OperationClaims;

namespace Business.Handlers.OperationClaims.Commands
{
    public class DeleteOperationClaimCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, IResult>
        {
            private readonly IOperationClaimService _operationClaimService;
            private readonly IMapper _mapper;
            public DeleteOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper)
            {
                _operationClaimService = operationClaimService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<OperationClaimDto>(request);
                var operationClaim = await _operationClaimService.DeleteAsync(mapper);
                return operationClaim;

            }
        }
    }
}