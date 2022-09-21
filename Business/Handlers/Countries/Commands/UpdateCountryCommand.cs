using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Countries.Commands
{
    public class UpdateCountryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;          

            public UpdateCountryCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;        
            }

            public async Task<IResult> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                Country country = await _unitOfWork.CountryRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.CountryRepository.UpdateAsync(country);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CountryUpdated);
            }

        }
    }
}