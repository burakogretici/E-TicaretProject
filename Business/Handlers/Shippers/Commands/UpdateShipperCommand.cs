using AutoMapper;
using Core.Utilities.Results;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using Business.Services.Shippers;
using Entities.Dtos.Shippers;

namespace Business.Handlers.Shippers.Commands
{
    public class UpdateShipperCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public class UpdateShipperCommandHandler : IRequestHandler<UpdateShipperCommand, IResult>
        {
            private readonly IShipperService _shipperService;
            private readonly IMapper _mapper;
            public UpdateShipperCommandHandler(IShipperService shipperService, IMapper mapper)
            {
                _shipperService = shipperService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateShipperCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ShipperDto>(request);
                var shipper = await _shipperService.UpdateAsync(mapper);
                return shipper;

            }

        }
    }
}
