using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Suppliers.Commands;
using Business.Handlers.Suppliers.Queries;
using Entities.Dtos.Suppliers;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(SupplierDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetSupplierQuery getSupplierQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getSupplierQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSupplierCommand createSupplier)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createSupplier));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand updateSupplier)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateSupplier));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSupplierCommand deleteSupplier)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteSupplier));

        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<SupplierDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetSuppliersQuery()));
        }

    }
}
