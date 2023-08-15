using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class MenuRules
    {
        private readonly IMenuRepository _menuRepository;

        public MenuRules(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task MenuNameAlreadyExists(string menuDtoName)
        {
            var result = await _menuRepository.AnyAsync(b => b.Name == menuDtoName);
            if (result) throw new BusinessException(Messages.MenuNameAlreadyExists);
        }
    }
}