using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Brands;
using Core.Utilities.Results;
using Entities.Dtos.Brands;
using MediatR;

namespace Business.Handlers.Brands.Queries
{
    public class GetBrandQuery : IRequest<IDataResult<BrandDto>>
    {
        public Guid Id { get; set; }

        public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, IDataResult<BrandDto>>
        {
            private readonly IBrandService _brandService;

            public GetBrandQueryHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }
            public async Task<IDataResult<BrandDto>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
            {
                var brand = await _brandService.GetByIdAsync(request.Id);
                return brand;
            }
        }
    }
}
