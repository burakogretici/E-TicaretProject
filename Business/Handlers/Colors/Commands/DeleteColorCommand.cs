using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Colors.Commands
{
    public class DeleteColorCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;           

            public DeleteColorCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;            
            }

            public async Task<IResult> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                Color color = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.ColorRepository.DeleteAsync(color);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ColorDeleted);
            }

        }
    }
}
