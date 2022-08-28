using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.OperationClaims.Commands
{
    public class UpdateOperationClaimCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
           
            public UpdateOperationClaimCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;              
            }

            public async Task<IResult> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _unitOfWork.OperationClaimRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.OperationClaimRepository.UpdateAsync(operationClaim);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OperationClaimUpdated);
            }
        }
    }
}

