using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Cities;
using Core.Utilities.Results;
using Entities.Dtos.Cities;
using MediatR;

namespace Business.Handlers.Cities.Queries
{
    public class GetCityQuery : IRequest<IDataResult<CityDto>>
    {
        public Guid Id { get; set; }

        public class GetCityQueryHandler : IRequestHandler<GetCityQuery, IDataResult<CityDto>>
        {
            private readonly ICityService _cityService;

            public GetCityQueryHandler(ICityService cityService)
            {
                _cityService = cityService;
            }
            public async Task<IDataResult<CityDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
            {
                var city = await _cityService.GetByIdAsync(request.Id);
                return city;
            }
        }
    }
}
