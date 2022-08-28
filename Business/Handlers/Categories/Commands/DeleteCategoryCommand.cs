using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
           
            public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;         
            }

            public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.CategoryRepository.DeleteAsync(category);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CategoryDeleted);
            }
        }
    }
}
