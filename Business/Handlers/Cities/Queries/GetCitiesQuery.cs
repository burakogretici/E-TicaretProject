using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Cities;
using Core.Utilities.Results;
using Entities.Dtos.Cities;
using MediatR;

namespace Business.Handlers.Cities.Queries
{
    public class GetCitiesQuery : IRequest<IDataResult<IEnumerable<CityDto>>>
    {
        public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IDataResult<IEnumerable<CityDto>>>
        {
            private readonly ICityService _cityService;

            public GetCitiesQueryHandler(ICityService cityService)
            {
                _cityService = cityService;
            }

            public async Task<IDataResult<IEnumerable<CityDto>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
            {
                var cityList = await _cityService.GetAllAsync();
                return cityList;
            }
        }
    }
}
