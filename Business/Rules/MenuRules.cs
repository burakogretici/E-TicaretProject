using Business.Constants;
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

        public async Task<IResult> MenuNameAlreadyExists(string menuDtoName)
        {
            var result = await _menuRepository.AnyAsync(b => b.Name == menuDtoName);
            if (!result)
                return new SuccessResult();
            else
                return new ErrorResult(Messages.MenuNameAlreadyExists);
        }
    }
}