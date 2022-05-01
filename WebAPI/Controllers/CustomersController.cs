using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Customers.Commands;
using Business.Handlers.Customers.Queries;
using Entities.Dtos.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCustomersQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCustomerQuery getCustomerQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCustomerQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomer)

        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createCustomer));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCustomer));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCustomer));

        }
    }
}

