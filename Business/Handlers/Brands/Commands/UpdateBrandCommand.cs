using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Brands;
using Core.Utilities.Results;
using Entities.Dtos.Brands;
using MediatR;

namespace Business.Handlers.Brands.Commands
{
    public class UpdateBrandCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, IResult>
        {
            private readonly IBrandService _brandService;
            private readonly IMapper _mapper;
            public UpdateBrandCommandHandler(IBrandService brandService, IMapper mapper)
            {
                _brandService = brandService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<BrandDto>(request);
                var brand = await _brandService.UpdateAsync(mapper);
                return brand;

            }
        }
    }
}
