using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.BasketItems.Queries;
using Business.Handlers.Baskets.Commands;
using Business.Handlers.Baskets.Queries;
using Entities.Dtos.Baskets;
using Microsoft.AspNetCore.Http;
using Business.Handlers.BasketItems.Commands;

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
            return GetResponseOnlyResultData(await Mediator.Send(new GetBasketsQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasketDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBasketItemQuery getBasketQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getBasketQuery));
        }

        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBasketCommand createBasket)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createBasket));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add-basketItem")]
        public async Task<IActionResult> AddBasketItem([FromBody] CreateBasketItemCommand createBasketItem)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createBasketItem));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasketCommand updateBasket)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateBasket));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBasketCommand deleteBasket)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteBasket));
        }
    }
}
