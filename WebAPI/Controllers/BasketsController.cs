using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.BasketItems.Queries;
using Business.Handlers.Baskets.Commands;
using Business.Handlers.Baskets.Queries;
using Entities.Dtos.Baskets;
using Microsoft.AspNetCore.Http;
using Business.Handlers.BasketItems.Commands;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : BaseController
    {
      
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<BasketListDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResult(await Mediator.Send(new GetBasketsQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasketDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBasketItemQuery getBasketQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getBasketQuery));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<BasketListDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-basketItems")]
        public async Task<IActionResult> GetBasketItems([FromQuery] TableGlobalFilter tableGlobalFilter)
        {
            GetBasketItemsQuery getBasketItemsQuery = new() { TableGlobalFilter = tableGlobalFilter };
            return GetResponseOnlyResult(await Mediator.Send(getBasketItemsQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBasketCommand createBasket)
        {
            return GetResponseOnlyResult(await Mediator.Send(createBasket));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add-basketItem")]
        public async Task<IActionResult> AddBasketItem([FromBody] CreateBasketItemCommand createBasketItem)
        {
            return GetResponseOnlyResult(await Mediator.Send(createBasketItem));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasketCommand updateBasket)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateBasket));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBasketCommand deleteBasket)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteBasket));
        }
    }
}
