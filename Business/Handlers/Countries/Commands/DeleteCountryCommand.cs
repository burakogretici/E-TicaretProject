using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Countries.Commands
{
    public class DeleteCountryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;          

            public DeleteCountryCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;              
            }

            public async Task<IResult> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                Country country = await _unitOfWork.CountryRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.CountryRepository.DeleteAsync(country);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CountryDeleted);
            }
        }
    }
}
