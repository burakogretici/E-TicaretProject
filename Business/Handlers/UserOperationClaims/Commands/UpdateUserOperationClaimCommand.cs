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
            private readonly IMapper _mapper;


            public UpdateUserOperationClaimCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;

            }

            public async Task<IResult> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<UserOperationClaim>(request);
                await _unitOfWork.UserOperationClaimRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserOperationClaimUpdated);
            }
        }
    }
}