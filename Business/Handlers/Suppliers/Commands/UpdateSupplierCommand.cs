using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Suppliers.Commands
{
    public class UpdateSupplierCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }

        public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;           

            public UpdateSupplierCommandHandler(IUnitOfWork unitOfWork)
            {               
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
            {
                Supplier supplier = await _unitOfWork.SupplierRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.SupplierRepository.UpdateAsync(supplier);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.SupplierUpdated);
            }
        }
    }
}
