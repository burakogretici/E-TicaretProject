using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Business.Handlers.Shippers.Commands
{
    public class DeleteShipperCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteShipperCommandHandler : IRequestHandler<DeleteShipperCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteShipperCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteShipperCommand request, CancellationToken cancellationToken)
            {
                //Shipper shipper = await _unitOfWork.ShipperRepository.GetAsync(x => x.Id == request.Id);
                //await _unitOfWork.ShipperRepository.DeleteAsync(shipper);
                //await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandDeleted);
            }
        }
    }
}
