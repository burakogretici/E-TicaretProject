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
    public class DeleteBrandCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, IResult>
        {
            private readonly IBrandService _brandService;
            private readonly IMapper _mapper;
            public DeleteBrandCommandHandler(IBrandService brandService, IMapper mapper)
            {
                _brandService = brandService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<BrandDto>(request);
                var brand = await _brandService.DeleteAsync(mapper);
                return brand;

            }
        }
    }
}
