using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<IResult>
    {
        public Guid CustomerId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }

        public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Address>(request);
                await _unitOfWork.AddressRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.AddressAdded);
            }
        }
    }
}

