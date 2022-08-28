using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Cities;
using MediatR;

namespace Business.Handlers.Cities.Queries
{
    public class GetCityQuery : IRequest<IDataResult<CityDto>>
    {
        public Guid Id { get; set; }

        public class GetCityQueryHandler : IRequestHandler<GetCityQuery, IDataResult<CityDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetCityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<CityDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
            {
                var city = await _unitOfWork.CityRepository.GetAsync(a => a.Id == request.Id);
                var cityDto = _mapper.Map<CityDto>(city);
                return new SuccessDataResult<CityDto>(cityDto);
            }
        }
    }
}
