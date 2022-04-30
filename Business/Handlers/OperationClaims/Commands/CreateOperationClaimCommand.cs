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
    public class CreateOperationClaimCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateOperationClaimCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<OperationClaim>(request);
                await _unitOfWork.OperationClaimRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OperationClaimAdded);
            }
        }
    }
}
