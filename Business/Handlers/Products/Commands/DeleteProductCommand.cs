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
    public class DeleteProductCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;            

            public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.ProductRepository.DeleteAsync(product);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ProductDeleted);
            }
        }
    }
}
