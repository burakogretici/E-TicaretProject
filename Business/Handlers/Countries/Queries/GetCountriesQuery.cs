using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Countries;
using MediatR;

namespace Business.Handlers.Countries.Queries
{
    public class GetCountriesQuery : IRequest<IDataResult<IEnumerable<CountryDto>>>
    {
        public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IDataResult<IEnumerable<CountryDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCountriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<CountryDto>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
            {
                var countryList = await _unitOfWork.CountryRepository.GetAllAsync(
                    selector: x => new CountryDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                    },
                    orderBy: x => x.OrderBy(x => x.Name)
                );

                return new SuccessDataResult<IEnumerable<CountryDto>>(countryList);

            }
        }
    }
}

