using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
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
            private readonly IUnitOfWork _unitOfWork;

            public UpdateUserOperationClaimCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = await _unitOfWork.UserOperationClaimRepository.GetAsync(x => x.OperationClaimId == request.Id);
                await _unitOfWork.UserOperationClaimRepository.UpdateAsync(userOperationClaim);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserOperationClaimUpdated);
            }
        }
    }
}