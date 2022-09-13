using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Colors;
using Core.Utilities.Results;
using Entities.Dtos.Colors;
using MediatR;

namespace Business.Handlers.Colors.Queries
{
    public class GetColorQuery : IRequest<IDataResult<ColorDto>>
    {
        public Guid Id { get; set; }

        public class GetColorQueryHandler : IRequestHandler<GetColorQuery, IDataResult<ColorDto>>
        {
            private readonly IColorService _colorService;

            public GetColorQueryHandler(IColorService colorService)
            {
                _colorService = colorService;
            }

            public async Task<IDataResult<ColorDto>> Handle(GetColorQuery request, CancellationToken cancellationToken)
            {
                var color = await _colorService.GetByIdAsync(request.Id);
                return color;
            }
        }
    }
}
