using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Users.Commands
{
    public class DeleteUserCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;              
            }

            public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _unitOfWork.UserRepository.GetAsync(p => p.Id == request.Id);
                if (user != null)
                {
                    await _unitOfWork.UserRepository.DeleteAsync(user);
                    await _unitOfWork.Commit();
                }

                return new SuccessResult(Messages.UserDeleted);
            }
        }
    }
}
