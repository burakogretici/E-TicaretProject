using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.UserOperationClaim;

namespace Business.Services.UserOperationClaims
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserOperationClaimManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IResult> AddAsync(UserOperationClaimDto userOperationClaimOperationClaimDto)
        {
            var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimOperationClaimDto);
            await _unitOfWork.UserOperationClaimRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<UserOperationClaimDto>(userOperationClaimOperationClaimDto, Messages.UserOperationClaimAdded);

        }

        public async Task<IResult> UpdateAsync(UserOperationClaimDto userOperationClaimOperationClaimDto)
        {
            var userOperationClaimOperationClaim = await GetByIdAsync(userOperationClaimOperationClaimDto.Id);
            if (userOperationClaimOperationClaim.Data != null)
            {
                userOperationClaimOperationClaim.Data.UserId = userOperationClaimOperationClaimDto.UserId;
                userOperationClaimOperationClaim.Data.OperationClaimId = userOperationClaimOperationClaimDto.OperationClaimId;
                var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimOperationClaim.Data);
                await _unitOfWork.UserOperationClaimRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserOperationClaimUpdated);

            }
            return userOperationClaimOperationClaim;
        }

        public async Task<IResult> DeleteAsync(UserOperationClaimDto userOperationClaimOperationClaimDto)
        {
            var userOperationClaimOperationClaim = await GetByIdAsync(userOperationClaimOperationClaimDto.Id);
            if (userOperationClaimOperationClaim.Data != null)
            {
                var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimOperationClaim.Data);
                await _unitOfWork.UserOperationClaimRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserOperationClaimDeleted);
            }

            return userOperationClaimOperationClaim;

        }

        public async Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.UserOperationClaimRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new UserOperationClaimDto
                {
                    UserId = x.UserId,
                    OperationClaimId = x.OperationClaimId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<UserOperationClaimDto>>(result, Messages.UserOperationClaimListed);
        }

        public async Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllByOperationClaim(Guid operationClaimId)
        {
            var result = await _unitOfWork.UserOperationClaimRepository.GetAllAsync(expression: x => x.Deleted != true && x.OperationClaimId == operationClaimId,
                selector: x => new UserOperationClaimDto
                {
                    UserId = x.UserId,
                    OperationClaimId = x.OperationClaimId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<UserOperationClaimDto>>(result, Messages.UserOperationClaimListed);
        }

        public async Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllByUser(Guid userId)
        {
            var result = await _unitOfWork.UserOperationClaimRepository.GetAllAsync(expression: x => x.Deleted != true && x.UserId == userId,
                selector: x => new UserOperationClaimDto
                {
                    UserId = x.UserId,
                    OperationClaimId = x.OperationClaimId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<UserOperationClaimDto>>(result, Messages.UserOperationClaimListed);
        }

        public async Task<IDataResult<UserOperationClaimDto>> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.UserOperationClaimRepository.GetAsync(br => br.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<UserOperationClaimDto>(Messages.UserOperationClaimNotFound);
            }
            var mapper = _mapper.Map<UserOperationClaimDto>(result);
            return new SuccessDataResult<UserOperationClaimDto>(mapper);
        }
    }
}

