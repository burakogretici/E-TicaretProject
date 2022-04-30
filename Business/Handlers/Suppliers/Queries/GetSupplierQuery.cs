using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Suppliers;
using MediatR;

namespace Business.Handlers.Suppliers.Queries
{
    public class GetSupplierQuery : IRequest<IDataResult<SupplierDto>>
    {
        public Guid Id { get; set; }

        public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, IDataResult<SupplierDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetSupplierQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<SupplierDto>> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
            {
                var supplier = await _unitOfWork.SupplierRepository.GetAsync(a => a.Id == request.Id);
                var supplierDto = _mapper.Map<SupplierDto>(supplier);
                return new SuccessDataResult<SupplierDto>(supplierDto);
            }
        }
    }
}
