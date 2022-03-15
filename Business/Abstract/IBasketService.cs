using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBasketService 
    {
        Task<IResult> AddToCartAsync(Basket basket);
        Task<IResult> UpdateAsync(Basket basket);
        Task<IResult> DeleteFromCartAsync(Basket basket);

        Task<IDataResult<IEnumerable<Basket>>> GetAllAsync();
        Task<IDataResult<Basket>> GetByIdAsync(Guid id);

    }
}
