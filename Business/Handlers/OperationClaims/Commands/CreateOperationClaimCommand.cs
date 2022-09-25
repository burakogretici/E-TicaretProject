using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.OperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.OperationClaims;
using MediatR;

namespace Business.Handlers.OperationClaims.Commands
{
    public class CreateOperationClaimCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, IResult>
        {
            private readonly IOperationClaimService _operationClaimService;
            private readonly IMapper _mapper;
            public CreateOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper)
            {
                _operationClaimService = operationClaimService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<OperationClaimDto>(request);
                var operationClaim = await _operationClaimService.AddAsync(mapper);
                return operationClaim;
            }
        }
    }
}
