using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class ColorRules
    {
        private readonly IColorRepository _colorDal;

        public ColorRules(IColorRepository colorDal) => _colorDal = colorDal;

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
