using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.UserOperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.UserOperationClaim;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Commands
{
    public class CreateUserOperationClaimCommand : IRequest<IResult>
    {
        public Guid UserId { get; set; }
        public List<Guid> OperationClaimIds { get; set; }


        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, IResult>
        {
            private readonly IUserOperationClaimService _userOperationClaimService;
            private readonly IMapper _mapper;
            public CreateUserOperationClaimCommandHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper)
            {
                _userOperationClaimService = userOperationClaimService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserOperationClaimDto>(request);
                var userOperationClaim = await _userOperationClaimService.AddAsync(mapper);
                return userOperationClaim;
            }
        }
    }
}
