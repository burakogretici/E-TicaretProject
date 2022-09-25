using AutoMapper;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.OperationClaims
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly OperationClaimRules _operationClaimRules;

        public OperationClaimManager(IMapper mapper, IUnitOfWork unitOfWork, OperationClaimRules operationClaimRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _operationClaimRules = operationClaimRules;
        }


        public async Task<IDataResult<OperationClaimDto>> AddAsync(OperationClaimDto model)
        {
            IResult result = BusinessRules.Run(await _operationClaimRules.OperationClaimAlreadyExists(model.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<OperationClaim>(model);
                await _unitOfWork.OperationClaimRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<OperationClaimDto>(model, Messages.OperationClaimAdded);
            }

            return new ErrorDataResult<OperationClaimDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(OperationClaimDto operationClaimDto)
        {
            var operationClaim = await GetByIdAsync(operationClaimDto.Id);
            if (operationClaim.Data != null)
            {
                IResult result =
                    BusinessRules.Run(await _operationClaimRules.OperationClaimAlreadyExists(operationClaimDto.Name));
                if (result == null)
                {
                    operationClaim.Data.Name = operationClaimDto.Name;
                    var mapper = _mapper.Map<OperationClaim>(operationClaim.Data);
                    await _unitOfWork.OperationClaimRepository.UpdateAsync(mapper);
                    await _unitOfWork.Commit();
                    return new SuccessResult(Messages.OperationClaimUpdated);
                }

                return result;
            }

            return operationClaim;
        }

        public async Task<IResult> DeleteAsync(OperationClaimDto operationClaimDto)
        {
            var operationClaim = await GetByIdAsync(operationClaimDto.Id);
            if (operationClaim.Data != null)
            {
                var mapper = _mapper.Map<OperationClaim>(operationClaim.Data);
                await _unitOfWork.OperationClaimRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OperationClaimDeleted);
            }

            return operationClaim;

        }

        public async Task<IDataResult<IEnumerable<OperationClaimDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.OperationClaimRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new OperationClaimDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<OperationClaimDto>>(result, Messages.OperationClaimListed);
        }

        public async Task<IDataResult<OperationClaimDto>> GetByIdAsync(Guid operationClaimId)
        {
            var result = await _unitOfWork.OperationClaimRepository.GetAsync(br => br.Id == operationClaimId);
            if (result == null)
            {
                return new ErrorDataResult<OperationClaimDto>(Messages.OperationClaimNotFound);
            }

            var mapper = _mapper.Map<OperationClaimDto>(result);
            return new SuccessDataResult<OperationClaimDto>(mapper);
        }
    }
}