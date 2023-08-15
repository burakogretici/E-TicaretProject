using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Shippers;
using Core.Utilities.Results;
using Entities.Dtos.Shippers;
using MediatR;

namespace Business.Handlers.Shippers.Commands
{
    public class CreateShipperCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string Phone { get; set; }


        public class CreateShipperCommandHandler : IRequestHandler<CreateShipperCommand, IResult>
        {
            private readonly IShipperService _shipperService;
            private readonly IMapper _mapper;
            public CreateShipperCommandHandler(IShipperService shipperService, IMapper mapper)
            {
                _shipperService = shipperService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateShipperCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ShipperDto>(request);
                var shipper = await _shipperService.AddAsync(mapper);
                return shipper;
            }
        }
    }
}
