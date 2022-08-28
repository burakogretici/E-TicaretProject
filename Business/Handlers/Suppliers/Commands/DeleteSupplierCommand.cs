using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Suppliers.Commands
{
    public class DeleteSupplierCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        
        public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteSupplierCommandHandler(IUnitOfWork unitOfWork)
            {            
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
            {
                Supplier supplier = await _unitOfWork.SupplierRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.SupplierRepository.DeleteAsync(supplier);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.SupplierDeleted);
            }
        }
    }
}
