using System.Threading.Tasks;
using Business.Handlers.OrderDetails.Commands;
using Business.Handlers.OrderDetails.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderDetailCommand createOrderDetail)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createOrderDetail));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderDetailCommand deleteOrderDetail)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteOrderDetail));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOrderDetailQuery getOrderDetailQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getOrderDetailQuery));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDetailCommand updateOrderDetail)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateOrderDetail));
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetOrderDetailsQuery()));
        }
    }
}
