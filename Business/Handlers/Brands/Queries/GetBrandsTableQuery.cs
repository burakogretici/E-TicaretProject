using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Brands;
using Business.Services.Products;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Brands;
using MediatR;

namespace Business.Handlers.Brands.Queries
{
    public class GetBrandsTableQuery : IRequest<PaginatedResult<BrandDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }
        public class GetBrandsTableQueryHandler : IRequestHandler<GetBrandsTableQuery, PaginatedResult<BrandDto>>
        {
            private readonly IBrandService _brandService;

            public GetBrandsTableQueryHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<PaginatedResult<BrandDto>> Handle(GetBrandsTableQuery request, CancellationToken cancellationToken)
            {
                var brandList = await _brandService.GetTableSearch(request.TableGlobalFilter);
                return brandList;
            }
        }
    }
}
