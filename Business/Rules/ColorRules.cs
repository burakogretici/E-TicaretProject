using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class ColorRules
    {
        private readonly IColorDal _colorDal;

        public ColorRules(IColorDal colorDal) => _colorDal = colorDal;

        private IResult ColorNameAlreadyExists(string colorName)
        {
            var result = _colorDal.AnyAsync(c => c.Name == colorName).Result;
            if (result)
            {
                return new ErrorResult(Messages.ColorNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
