using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBasketService 
    {
        IResult AddToCart(Basket basket);
        IResult Update(Basket basket);
        IResult DeleteFromCart(Basket basket);

        Task<IDataResult<IEnumerable<Basket>>> GetAllAsync();
        Task<IDataResult<Basket>> GetByIdAsync(Guid id);

    }
}
