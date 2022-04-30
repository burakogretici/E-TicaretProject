using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Colors.Commands
{
    public class CreateColorCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateColorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Color>(request);
                await _unitOfWork.ColorRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ColorAdded);
            }
        }
    }
}

