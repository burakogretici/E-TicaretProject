using System.Threading.Tasks;
using Business.Handlers.Orders.Commands;
using Business.Handlers.Orders.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetOrdersQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOrderQuery getOrderQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getOrderQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createOrder));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand updateOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateOrder));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand deleteOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteOrder));
        }
    }
}
