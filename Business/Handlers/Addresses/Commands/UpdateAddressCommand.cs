using AutoMapper;
using Business.Constants;
using Business.Handlers.Brands.Commands;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Business.Handlers.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                Address address = await _unitOfWork.AddressRepository.GetAsync(x => x.Id == request.Id);
                if (address != null)
                {
                    address.CustomerId = request.CustomerId;
                    address.CountryId = request.CountryId;
                    address.CityId = request.CityId;
                    address.AddressDetail = request.AddressDetail;
                    address.PostalCode = request.PostalCode;
                }

                await _unitOfWork.AddressRepository.UpdateAsync(address);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandUpdated);
            }
        }
    }
}
