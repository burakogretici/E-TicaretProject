using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Countries;
using Core.Utilities.Results;
using Entities.Dtos.Countries;
using MediatR;

namespace Business.Handlers.Countries.Commands
{
    public class CreateCountryCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateCountryCommandHandler:IRequestHandler<CreateCountryCommand,IResult>
        {
            private readonly ICountryService _countryService;
            private readonly IMapper _mapper;
            public CreateCountryCommandHandler(ICountryService countryService, IMapper mapper)
            {
                _countryService = countryService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CountryDto>(request);
                var country = await _countryService.AddAsync(mapper);
                return country;
            }
        }
    }
}
