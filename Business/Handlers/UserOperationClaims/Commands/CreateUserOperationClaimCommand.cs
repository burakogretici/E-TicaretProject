using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Commands
{
    public class CreateUserOperationClaimCommand : IRequest<IResult>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }


        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;


            public CreateUserOperationClaimCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;

            }
            public async Task<IResult> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Entities.Concrete.UserOperationClaim>(request);
                await _unitOfWork.UserOperationClaimRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserOperationClaimAdded);
            }
        }
    }
}
