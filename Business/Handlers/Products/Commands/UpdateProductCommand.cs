using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Products;
using Core.Utilities.Results;
using Entities.Dtos;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Commands
{
    public class UpdateProductCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResult>
        {
            private readonly IProductService _productService;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ProductDto>(request);
                var product = await _productService.UpdateAsync(mapper);
                return product;
            }
        }
    }
}