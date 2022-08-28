using System;
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
    public class UpdateColorCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateColorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                Color color = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == request.Id);
                if (color == null) return null;
                await _unitOfWork.ColorRepository.UpdateAsync(color);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ColorUpdated);
            }
        }
    }
}
