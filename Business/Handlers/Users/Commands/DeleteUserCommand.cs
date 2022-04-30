using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using MediatR;

namespace Business.Handlers.Users.Commands
{
    public class DeleteUserCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var userToDelete = await _unitOfWork.UserRepository.GetAsync(p => p.Id == request.Id);
                if (userToDelete != null)
                {
                    userToDelete.IsActive = false;
                    await _unitOfWork.UserRepository.UpdateAsync(userToDelete);
                    await _unitOfWork.Commit();
                }

                return new SuccessResult(Messages.UserDeleted);
            }
        }
    }
}
