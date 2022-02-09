using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBasketService 
    {
        IResult AddToCart(Basket basket);
        IResult Update(Basket basket);
        IResult DeleteFromCart(Basket basket);

        IDataResult<IEnumerable<Basket>> GetAll();
        IDataResult<Basket> GetById(int id);

    }
}
