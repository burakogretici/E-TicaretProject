using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class OperationClaimRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimAlreadyExists(string claim)
        {
            var result = await _operationClaimRepository.AnyAsync(b => b.Name == claim);
            if (result) throw new BusinessException(Messages.OperationClaimExists);

        }
    }
}