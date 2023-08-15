using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ColorRules
    {
        private readonly IColorRepository _colorRepository;

        public ColorRules(IColorRepository colorRepository) => _colorRepository = colorRepository;

        public async Task ColorNameAlreadyExists(string colorName)
        {
            var result = await _colorRepository.AnyAsync(c => c.Name == colorName);
            if (result) throw new BusinessException(Messages.ColorNameAlreadyExists);

        }
    }
}
