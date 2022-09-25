using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.UserOperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.UserOperationClaim;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Commands
{
    public class UpdateUserOperationClaimCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }


        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, IResult>
        {
            private readonly IUserOperationClaimService _userOperationClaimService;
            private readonly IMapper _mapper;
            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper)
            {
                _userOperationClaimService = userOperationClaimService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserOperationClaimDto>(request);
                var userOperationClaim = await _userOperationClaimService.UpdateAsync(mapper);
                return userOperationClaim;

            }
        }
    }
}