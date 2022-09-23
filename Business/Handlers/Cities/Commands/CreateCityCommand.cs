using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Cities;
using Core.Utilities.Results;
using Entities.Dtos.Cities;
using MediatR;

namespace Business.Handlers.Cities.Commands
{
    public class CreateCityCommand : IRequest<IResult>
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, IResult>
        {
            private readonly ICityService _cityService;
            private readonly IMapper _mapper;
            public CreateCityCommandHandler(ICityService cityService, IMapper mapper)
            {
                _cityService = cityService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CityDto>(request);
                var city = await _cityService.AddAsync(mapper);
                return city;
            }
        }
    }
}