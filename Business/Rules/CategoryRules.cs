using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CategoryRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameAlreadyExists(string categoryName)
        {
            var result = await _categoryRepository.AnyAsync(b => b.Name == categoryName);
            if (result) throw new BusinessException(Messages.CategoryNameAlreadyExists);
        }
    }
}