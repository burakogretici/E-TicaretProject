using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IResult AddToCart(Basket basket)
        {
            _basketDal.Add(basket);
            return new SuccessResult(Messages.BasketAdded);
        }

        public IResult Update(Basket basket)
        {
           _basketDal.Update(basket);
            return new SuccessResult(Messages.BasketUpdated);
        }

        public IResult DeleteFromCart(Basket basket)
        {
           _basketDal.Delete(basket);
            return new SuccessResult(Messages.BasketDeleted);
        }
        
        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll(),Messages.BasketListed);
        }

        public IDataResult<Basket> GetById(int basketId)
        {
            return new SuccessDataResult<Basket>(_basketDal.Get(b => b.Id == basketId));
        }
    }
}
