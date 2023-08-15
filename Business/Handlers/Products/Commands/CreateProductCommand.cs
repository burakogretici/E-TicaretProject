using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Products;
using Core.Utilities.Results;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Commands
{
    public class CreateProductCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IResult>
        {
            private readonly IProductService _productService;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }


            public async Task<IResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ProductDto>(request);
                var product = await _productService.AddAsync(mapper);
                return product;
            }
        }
    }
}