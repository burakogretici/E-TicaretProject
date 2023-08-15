using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Colors;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Colors;
using MediatR;

namespace Business.Handlers.Colors.Queries
{
    public class GetColorsTableQuery : IRequest<PaginatedResult<ColorDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }

        public class GetColorsQueryHandler : IRequestHandler<GetColorsTableQuery, PaginatedResult<ColorDto>>
        {
            private readonly IColorService _colorService;

            public GetColorsQueryHandler(IColorService colorService)
            {
                _colorService = colorService;
            }

            public async Task<PaginatedResult<ColorDto>> Handle(GetColorsTableQuery request, CancellationToken cancellationToken)
            {
                var colorList = await _colorService.GetTableSearch(request.TableGlobalFilter);
                return colorList;
            }
        }
    }
}
