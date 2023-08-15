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
    public class DeleteUserOperationClaimCommand : IRequest<IResult>
    {
        public Guid UserId { get; set; }
        public List<Guid> RoleIds { get; set; }


        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, IResult>
        {
            private readonly IUserOperationClaimService _userOperationClaimService;
            private readonly IMapper _mapper;
            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper)
            {
                _userOperationClaimService = userOperationClaimService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<DeleteUserOperationCLaimDto>(request);
                var userOperationClaim = await _userOperationClaimService.DeleteAsync(mapper);
                return userOperationClaim;

            }
        }
    }
}
