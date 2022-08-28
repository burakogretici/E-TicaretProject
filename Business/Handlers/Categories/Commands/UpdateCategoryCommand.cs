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
    public class UpdateCategoryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;      

            public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;              
            }

            public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.CategoryRepository.UpdateAsync(category);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CategoryUpdated);
            }
        }
    }
}
