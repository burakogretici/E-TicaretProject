using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.OrderDetails.Commands;
using Business.Handlers.OrderDetails.Queries;
using Entities.Dtos.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderDetailCommand createOrderDetail)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createOrderDetail));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderDetailCommand deleteOrderDetail)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteOrderDetail));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOrderDetailQuery getOrderDetailQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getOrderDetailQuery));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDetailCommand updateOrderDetail)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateOrderDetail));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDetailDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetOrderDetailsQuery()));
        }
    }
}
