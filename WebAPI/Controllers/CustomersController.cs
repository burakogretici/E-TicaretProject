using System.Threading.Tasks;
using Business.Handlers.Customers.Commands;
using Business.Handlers.Customers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCustomersQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCustomerQuery getCustomerQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCustomerQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomer)

        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createCustomer));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCustomer));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomer)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCustomer));

        }
    }
}

