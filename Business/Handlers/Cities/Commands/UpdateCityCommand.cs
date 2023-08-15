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
    public class UpdateCityCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, IResult>
        {
            private readonly ICityService _cityService;
            private readonly IMapper _mapper;
            public UpdateCityCommandHandler(ICityService cityService, IMapper mapper)
            {
                _cityService = cityService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CityDto>(request);
                var city = await _cityService.UpdateAsync(mapper);
                return city;
            }
        }
    }
}