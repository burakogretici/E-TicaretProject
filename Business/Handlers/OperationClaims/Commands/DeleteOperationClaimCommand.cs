using Business.Constants;
using Business.Handlers.Countries.Commands;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Business.Handlers.OperationClaims.Commands
{
    public class DeleteOperationClaimCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteOperationClaimHandler : IRequestHandler<DeleteOperationClaimCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteOperationClaimHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _unitOfWork.OperationClaimRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.OperationClaimRepository.DeleteAsync(operationClaim);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CountryDeleted);
            }
        }
    }
}