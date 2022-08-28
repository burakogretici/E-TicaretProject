using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
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
            private readonly IUnitOfWork _unitOfWork;         

            public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
            {             
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.ProductRepository.UpdateAsync(product);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ProductUpdated);
            }
        }
    }
}