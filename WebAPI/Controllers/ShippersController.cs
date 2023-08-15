using Business.Handlers.Cities.Commands;
using Business.Handlers.Cities.Queries;
using Business.Handlers.Shippers.Commands;
using Business.Handlers.Shippers.Queries;
using Entities.Dtos.Cities;
using Entities.Dtos.Shippers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ShippersController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateShipperCommand createShipper)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createShipper));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteShipperCommand deleteShipper)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteShipper));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateShipperCommand updateShipper)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateShipper));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ShipperDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCitiesQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShipperDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("delete/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetShipperQuery getShipperQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getShipperQuery));
        }
    }
}
