using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Commands
{
    public class DeleteUserOperationClaimCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;


            public DeleteUserOperationClaimCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;

            }
            public async Task<IResult> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Entities.Concrete.UserOperationClaim>(request);
                await _unitOfWork.UserOperationClaimRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserOperationClaimDeleted);
            }
        }
    }
}
