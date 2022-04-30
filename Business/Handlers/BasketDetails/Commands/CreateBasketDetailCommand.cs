using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using MediatR;

namespace Business.Handlers.BasketDetails.Commands
{
    public class CreateBasketDetailCommand : IRequest<IResult>
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }

        public class CreateBasketDetailCommandHandler : IRequestHandler<CreateBasketDetailCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateBasketDetailCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(CreateBasketDetailCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Entities.Concrete.BasketDetail>(request);
                await _unitOfWork.BasketDetailRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BasketAdded);
            }
        }
    }
}
