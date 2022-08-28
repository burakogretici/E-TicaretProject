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
     
            public DeleteAddressCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;          
            }

            public async Task<IResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                Address address = await _unitOfWork.AddressRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.AddressRepository.DeleteAsync(address);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.AddressDeleted);
            }
        }
    }
}
