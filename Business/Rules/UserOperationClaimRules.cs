using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using System;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UserOperationClaimRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }
        public async Task UserRoleAlreadyExists(Guid id)
        {
            var result = await _userOperationClaimRepository.AnyAsync(p => p.OperationClaimId == id);
            if (result) throw new BusinessException($"Bu kullanıcı zaten bu role sahip !");
        }
    }
}