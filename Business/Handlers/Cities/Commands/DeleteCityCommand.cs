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
    public class DeleteCityCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        
        public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, IResult>
        {
            private readonly ICityService _cityService;
            private readonly IMapper _mapper;
            public DeleteCityCommandHandler(ICityService cityService, IMapper mapper)
            {
                _cityService = cityService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CityDto>(request);
                var city = await _cityService.DeleteAsync(mapper);
                return city;

            }
        }
    }
}
