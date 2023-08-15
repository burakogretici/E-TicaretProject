using AutoMapper;
using Business.Services.UserOperationClaims;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserOperationClaim;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.UserOperationClaims.Queries
{
    public class GetByIdUserOperationClaimQuery : IRequest<IDataResult<UserOperationClaimListDto>>
    {
        public Guid Id { get; set; }

        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, IDataResult<UserOperationClaimListDto>>
        {
            private readonly IUserOperationClaimService _userOperationClaimService;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimService userOperationClaimService)
            {
                _userOperationClaimService = userOperationClaimService;
            }


            public async Task<IDataResult<UserOperationClaimListDto>> Handle(GetByIdUserOperationClaimQuery request,
                                                            CancellationToken cancellationToken)
            {
                var userOperationClaimList = await _userOperationClaimService.GetAllByUser(request.Id);
                return userOperationClaimList;
            }
        }
    }
}


