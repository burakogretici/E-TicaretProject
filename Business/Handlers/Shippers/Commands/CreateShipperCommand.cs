using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using MediatR;

namespace Business.Handlers.Shippers.Commands
{
    public class CreateShipperCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string Phone { get; set; }


        public class CreateShipperCommandHandler : IRequestHandler<CreateShipperCommand, IResult>
        {
            //    private readonly IUnitOfWork _unitOfWork;
            //private readonly IMapper _mapper;


            //public CreateShipperCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            //{
            //    _userOperationClaimRepository = userOperationClaimRepository;
            //    _mapper = mapper;

            public Task<IResult> Handle(CreateShipperCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
