using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Baskets;
using Entities.Dtos.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Baskets
{
    public interface IBasketService
    {
        Task<IDataResult<BasketDto>> CreateBasket(BasketDto basketDto);
        Task<IDataResult<BasketDto>> GetBasket(Guid basketId);
        Task<IDataResult<BasketDto>> GetBasketByUserId(Guid userId);
        Task<IDataResult<BasketItemDto>> AddItemToBasket(BasketItemDto basketDetailDto);

        Task<IResult> UpdateItemInBasket(BasketItemDto basketDetailDto);
        Task<IResult> RemoveItemFromBasket(Guid basketId, Guid productId);
        Task<IResult> ClearBasket(Guid basketId);
    }
}
