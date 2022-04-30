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
    public class DeleteAddressCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        
        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Address>(request);
                await _unitOfWork.AddressRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.AddressDeleted);
            }
        }
    }
}
