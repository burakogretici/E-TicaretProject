using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Queries
{
    public class GetProductsQuery : IRequest<IDataResult<IEnumerable<ProductDto>>>
    {
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IDataResult<IEnumerable<ProductDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<ProductDto>>> Handle(GetProductsQuery request,
                CancellationToken cancellationToken)
            {
                var countryList = await _unitOfWork.ProductRepository.GetAllAsync(
                    selector: x => new ProductDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CategoryName = x.Category.Name,
                        BrandName = x.Brand.Name,
                        ColorName = x.Color.Name,
                        SupplierName = x.Supplier.CompanyName,
                        Code = x.Code,
                        UnitPrice = x.UnitPrice,
                        UnitsInStock = x.UnitsInStock
                    },
                    orderBy: x => x.OrderBy(x => x.UnitPrice)
                );

                return new SuccessDataResult<IEnumerable<ProductDto>>(countryList);

            }
        }
    }
}