using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Addresses;
using MediatR;

namespace Business.Handlers.Addresses.Queries
{
    public class GetAddressQuery : IRequest<IDataResult<AddressDto>>
    {
        public Guid Id { get; set; }

        public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, IDataResult<AddressDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAddressQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<AddressDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
            {
                var address = await _unitOfWork.AddressRepository.GetAsync(a => a.Id == request.Id);
                var addressDto = _mapper.Map<AddressDto>(address);
                return new SuccessDataResult<AddressDto>(addressDto);
            }
        }
    }
}
