using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Colors;
using MediatR;

namespace Business.Handlers.Colors.Queries
{
    public class GetColorsQuery : IRequest<IDataResult<IEnumerable<ColorDto>>>
    {
        public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, IDataResult<IEnumerable<ColorDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetColorsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<ColorDto>>> Handle(GetColorsQuery request,
                CancellationToken cancellationToken)
            {
                var colorList = await _unitOfWork.ColorRepository.GetAllAsync(
                    selector: x => new ColorDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    orderBy: x => x.OrderBy(x => x.Name)
                );
                return new SuccessDataResult<IEnumerable<ColorDto>>(colorList);
            }
        }
    }
}
