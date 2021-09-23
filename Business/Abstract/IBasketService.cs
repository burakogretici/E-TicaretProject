using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBasketService
    {
        IResult AddToCart(Basket basket);
        IResult Update(Basket basket);
        IResult DeleteFromCart(Basket basket);

        IDataResult<List<Basket>> GetAll();
        IDataResult<Basket> GetById(int basket);

    }
}
