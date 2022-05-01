using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Orders.Commands;
using Business.Handlers.Orders.Queries;
using Entities.Dtos.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<OrderDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetOrdersQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOrderQuery getOrderQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getOrderQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createOrder));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand updateOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateOrder));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand deleteOrder)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteOrder));
        }
    }
}
