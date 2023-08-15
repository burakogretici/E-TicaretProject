using AutoMapper;
using Business.BusinessAspects;
using Business.Constants;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.OperationClaims
{
    public class OperationClaimManager : ServiceBase, IOperationClaimService
    {
        private readonly OperationClaimRules _operationClaimRules;

        public OperationClaimManager(IServiceProvider serviceProvider, OperationClaimRules operationClaimRules) : base(serviceProvider)
        {
            _operationClaimRules = operationClaimRules;
        }
        [SecuredOperation("OperationClaim.Add,Admin")]

        public async Task<IDataResult<OperationClaimDto>> AddAsync(OperationClaimDto model)
        {
            await _operationClaimRules.OperationClaimAlreadyExists(model.Name);

            var mapper = _mapper.Map<OperationClaim>(model);
            await _unitOfWork.OperationClaimRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<OperationClaimDto>(model, Messages.OperationClaimAdded);
        }
        [SecuredOperation("OperationClaim.Update,Admin")]

        public async Task<IResult> UpdateAsync(OperationClaimDto operationClaimDto)
        {
            var operationClaim = await GetByIdAsync(operationClaimDto.Id);

            await _operationClaimRules.OperationClaimAlreadyExists(operationClaimDto.Name);
            operationClaimDto.CreatedDate = operationClaim.Data.CreatedDate;

            var mapper = _mapper.Map<OperationClaim>(operationClaim.Data);
            await _unitOfWork.OperationClaimRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.OperationClaimUpdated);


        }
        [SecuredOperation("OperationClaim.Delete,Admin")]
        public async Task<IResult> DeleteAsync(OperationClaimDto operationClaimDto)
        {
            var operationClaim = await GetByIdAsync(operationClaimDto.Id);

            var mapper = _mapper.Map<OperationClaim>(operationClaim.Data);
            await _unitOfWork.OperationClaimRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.OperationClaimDeleted);

        }
        //[SecuredOperation("OperationClaim.List,Admin")]
        public async Task<IDataResult<IEnumerable<OperationClaimDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.OperationClaimRepository.GetAllAsync(
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
        [SecuredOperation("OperationClaim.Get,Admin")]
        public async Task<IDataResult<OperationClaimDto>> GetByIdAsync(Guid operationClaimId)
        {
            var result = await _unitOfWork.OperationClaimRepository.GetAsync(br => br.Id == operationClaimId);
            if (result == null) throw new BusinessException(Messages.OperationClaimNotFound);

            var mapper = _mapper.Map<OperationClaimDto>(result);
            return new SuccessDataResult<OperationClaimDto>(mapper);
        }
    }
}