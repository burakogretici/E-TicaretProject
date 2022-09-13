using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Colors;
using Core.Utilities.Results;
using Entities.Dtos.Colors;
using MediatR;

namespace Business.Handlers.Colors.Commands
{
    public class CreateColorCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, IResult>
        {
            private readonly IMapper _mapper;
            private readonly IColorService _colorService;

            public CreateColorCommandHandler(IMapper mapper, IColorService colorService)
            {
                _mapper = mapper;
                _colorService = colorService;
            }

            public async Task<IResult> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ColorDto>(request);
                var color = await _colorService.AddAsync(mapper);
                return color;
            }
        }
    }
}

