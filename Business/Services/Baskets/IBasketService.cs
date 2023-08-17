using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Baskets;

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
        Task<PaginatedResult<BasketListDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);

        Task<IDataResult<BasketItemDto>> AddItemToBasket(BasketItemDto basketDetailDto);

        Task<IResult> UpdateItemInBasket(BasketItemDto basketDetailDto);
        Task<IResult> RemoveItemFromBasket(Guid id);
        Task<IResult> ClearBasket(Guid basketId);
    }
}
