using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Cities;
using MediatR;

namespace Business.Handlers.Cities.Queries
{
    public class GetCitiesQuery : IRequest<IDataResult<IEnumerable<CityDto>>>
    {
        public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IDataResult<IEnumerable<CityDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCitiesQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<CityDto>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
            {
                var cityList = await _unitOfWork.CityRepository.GetAllAsync(
                     selector: x => new CityDto
                     {
                         Id = x.Id,
                         CountryName = x.Country.Name,
                         Name = x.Name
                     },
                     orderBy: x => x.OrderBy(x => x.Name)
                     );
                return new SuccessDataResult<IEnumerable<CityDto>>(cityList);
            }
        }
    }
}
