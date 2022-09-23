using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Colors;
using Core.Utilities.Results;
using Entities.Dtos.Colors;
using MediatR;

namespace Business.Handlers.Colors.Queries
{
    public class GetColorsQuery : IRequest<IDataResult<IEnumerable<ColorDto>>>
    {
        public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, IDataResult<IEnumerable<ColorDto>>>
        {
            private readonly IColorService _colorService;

            public GetColorsQueryHandler(IColorService colorService)
            {
                _colorService = colorService;
            }

            public async Task<IDataResult<IEnumerable<ColorDto>>> Handle(GetColorsQuery request,
                CancellationToken cancellationToken)
            {
                var colorList = await _colorService.GetAllAsync();
                return colorList;
            }
        }
    }
}
