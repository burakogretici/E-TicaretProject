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
    public class CreateSupplierCommand : IRequest<IResult>
    {
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateSupplierCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Supplier>(request);
                await _unitOfWork.SupplierRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.SupplierAdded);
            }
        }
    }
}
