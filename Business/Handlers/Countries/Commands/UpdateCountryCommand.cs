using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Countries;
using Core.Utilities.Results;
using Entities.Dtos.Countries;
using MediatR;

namespace Business.Handlers.Countries.Commands
{
    public class UpdateCountryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, IResult>
        {
            private readonly ICountryService _countryService;
            private readonly IMapper _mapper;
            public UpdateCountryCommandHandler(ICountryService countryService, IMapper mapper)
            {
                _countryService = countryService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CountryDto>(request);
                var country = await _countryService.UpdateAsync(mapper);
                return country;

            }

        }
    }
}