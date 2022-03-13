using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

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

        public async Task<IDataResult<IEnumerable<Basket>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<Basket>>(await _basketDal.GetAllAsync(), Messages.BasketListed);
        }

        public async Task<IDataResult<Basket>> GetByIdAsync(Guid basketId)
        {
            return new SuccessDataResult<Basket>(await _basketDal.GetAsync(b => b.Id == basketId));
        }
    }
}
