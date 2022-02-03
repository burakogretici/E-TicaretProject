using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBasketService 
    {
        IResult AddToCart(Basket country);
        IResult Update(Basket country);
        IResult DeleteFromCart(Basket country);

        IDataResult<List<Basket>> GetAll();
        IDataResult<Basket> GetById(int id);

    }
}
