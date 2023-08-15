using Core.Utilities.Results;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using Business.Services.Shippers;
using Entities.Dtos.Shippers;

namespace Business.Handlers.Shippers.Commands
{
    public class DeleteShipperCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteShipperCommandHandler : IRequestHandler<DeleteShipperCommand, IResult>
        {
            private readonly IShipperService _shipperService;
            private readonly IMapper _mapper;
            public DeleteShipperCommandHandler(IShipperService shipperService, IMapper mapper)
            {
                _shipperService = shipperService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteShipperCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ShipperDto>(request);
                var shipper = await _shipperService.DeleteAsync(mapper);
                return shipper;

            }
        }
    }
}
