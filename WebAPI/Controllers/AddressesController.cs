using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Addresses.Commands;
using Business.Handlers.Addresses.Queries;
using Entities.Dtos.Addresses;
using Entities.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAddressCommand createAddress)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createAddress));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAddressCommand deleteAddress)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteAddress));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AddressDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddress)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateAddress));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AddressDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetAddressesQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetAddressQuery getAddressQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getAddressQuery));
        }

        //[HttpGet("getallbycountryid")]
        //public async Task<IActionResult> GetAllByCountryId(Guid countryId)
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}
        //[HttpGet("getallbycityid")]
        //public async Task<IActionResult> GetAllByCityId(Guid cityId)
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}

        //[HttpGet("getallbyuserid")]
        //public async Task<IActionResult> GetAllByUserId(Guid userId)
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}

        //[HttpGet("getaddressdetail")]
        //public async Task<IActionResult> GetAddressDetail()
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}
    }
}

