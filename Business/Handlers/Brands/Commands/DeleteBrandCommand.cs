using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Brands.Commands
{
    public class DeleteBrandCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;         

            public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;          
            }

            public async Task<IResult> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.BrandRepository.DeleteAsync(brand);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandDeleted);
            }
        }
    }
}
