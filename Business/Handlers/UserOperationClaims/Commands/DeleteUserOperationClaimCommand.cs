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
    public class DeleteUserOperationClaimCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteUserOperationClaimCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IResult> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = await _unitOfWork.UserOperationClaimRepository.GetAsync(x => x.OperationClaimId == request.Id);
                await _unitOfWork.UserOperationClaimRepository.DeleteAsync(userOperationClaim);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserOperationClaimDeleted);
            }
        }
    }
}
