using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Brands;
using Core.Utilities.Results;
using Entities.Dtos.Brands;
using MediatR;

namespace Business.Handlers.Brands.Commands
{
    public class CreateBrandCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IResult>
        {
            private readonly IBrandService _brandService;
            private readonly IMapper _mapper;
            public CreateBrandCommandHandler(IBrandService brandService, IMapper mapper)
            {
                _brandService = brandService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<BrandDto>(request);
                var brand = await _brandService.AddAsync(mapper);
                return brand;
            }
        }
    }
}
