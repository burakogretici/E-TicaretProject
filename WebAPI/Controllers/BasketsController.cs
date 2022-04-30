using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.BasketDetails.Queries;
using Business.Handlers.Baskets.Commands;
using Business.Handlers.Baskets.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : BaseController
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetBasketsQuery()));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBasketDetailQuery getBasketQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getBasketQuery));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBasketCommand createBasket)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createBasket));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasketCommand updateBasket)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateBasket));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBasketCommand deleteBasket)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteBasket));
        }
    }
}
