using System;
using Core.Utilities.Results;
using Entities.Dtos.Shippers;
using MediatR;

namespace Business.Handlers.Shippers.Queries
{
    public class GetShipperQuery : IRequest<IDataResult<ShipperDto>>
    {
        public Guid Id { get; set; }

        //public class GetShipperQueryHandler : IRequestHandler<GetShipperQuery, IDataResult<ShipperDto>>
        //{
        //        private readonly IUnitOfWork _unitOfWork;
        //    private readonly IMapper _mapper;

        //    public GetShipperQueryHandler(IShipperRepository shipperRepository, IMapper mapper)
        //    {
        //        _shipperRepository = shipperRepository;
        //        _mapper = mapper;
        //    }

        //    public async Task<IDataResult<ShipperDto>> Handle(GetShipperQuery request, CancellationToken cancellationToken)
        //    {
        //        var shipper = await _shipperRepository.GetAsync(a => a.Id == request.Id);
        //        var shipperDto = _mapper.Map<ShipperDto>(shipper);
        //        return new SuccessDataResult<ShipperDto>(shipperDto);
        //    }
    }
}

