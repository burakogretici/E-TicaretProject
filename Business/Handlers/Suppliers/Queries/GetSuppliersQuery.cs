using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Suppliers;
using MediatR;

namespace Business.Handlers.Suppliers.Queries
{
    public class GetSuppliersQuery : IRequest<IDataResult<IEnumerable<SupplierDto>>>
    {
        public class
            GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, IDataResult<IEnumerable<SupplierDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetSuppliersQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<SupplierDto>>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
            {
                var supplierList = await _unitOfWork.SupplierRepository.GetAllAsync(
                    selector: x => new SupplierDto
                    {
                        Id = x.Id,
                        CustomerFullName = x.User.FirstName + " " + x.User.LastName,
                        CompanyName = x.CompanyName,
                        Website = x.Website,
                        Fax = x.Fax
                    }
                );
                return new SuccessDataResult<IEnumerable<SupplierDto>>(supplierList);
            }
        }
    }
}
