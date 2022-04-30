using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Colors;
using MediatR;

namespace Business.Handlers.Colors.Queries
{
    public class GetColorQuery : IRequest<IDataResult<ColorDto>>
    {
        public Guid Id { get; set; }

        public class GetColorQueryHandler : IRequestHandler<GetColorQuery, IDataResult<ColorDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetColorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<ColorDto>> Handle(GetColorQuery request, CancellationToken cancellationToken)
            {
                var color = await _unitOfWork.ColorRepository.GetAsync(a => a.Id == request.Id);
                var colorDto = _mapper.Map<ColorDto>(color);
                return new SuccessDataResult<ColorDto>(colorDto);
            }
        }
    }
}
