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
    public class UpdateUserCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;        

            public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;         
            }

            public async Task<IResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _unitOfWork.UserRepository.GetAsync(p => p.Id == request.Id);
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserUpdated);
            }
        }
    }
}