using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Products;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Commands
{
    public class DeleteProductCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResult>
        {
            private readonly IProductService _productService;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ProductDto>(request);
                var product = await _productService.DeleteAsync(mapper);
                return product;
            }
        }
    }
}
