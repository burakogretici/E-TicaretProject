using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Colors;
using Core.Utilities.Results;
using Entities.Dtos.Colors;
using MediatR;

namespace Business.Handlers.Colors.Commands
{
    public class UpdateColorCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, IResult>
        {
            private readonly IMapper _mapper;
            private readonly IColorService _colorService;

            public UpdateColorCommandHandler(IMapper mapper, IColorService colorService)
            {
                _mapper = mapper;
                _colorService = colorService;
            }

            public async Task<IResult> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<ColorDto>(request);
                var color = await _colorService.UpdateAsync(mapper);
                return color;
            }
        }
    }
}
