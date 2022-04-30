using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Suppliers.Commands;
using Business.Handlers.Suppliers.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : BaseController
    {
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetSupplierQuery getSupplierQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getSupplierQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSupplierCommand createSupplier)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createSupplier));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand updateSupplier)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateSupplier));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSupplierCommand deleteSupplier)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteSupplier));

        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetSuppliersQuery()));
        }

    }
}
