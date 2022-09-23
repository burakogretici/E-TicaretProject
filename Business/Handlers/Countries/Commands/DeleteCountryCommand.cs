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
    public class DeleteCountryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, IResult>
        {
            private readonly ICountryService _countryService;
            private readonly IMapper _mapper;
            public DeleteCountryCommandHandler(ICountryService countryService, IMapper mapper)
            {
                _countryService = countryService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CountryDto>(request);
                var country = await _countryService.DeleteAsync(mapper);
                return country;

            }
        }
    }
}
