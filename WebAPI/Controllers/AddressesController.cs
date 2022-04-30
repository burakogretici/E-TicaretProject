using System.Threading.Tasks;
using Business.Handlers.Addresses.Commands;
using Business.Handlers.Addresses.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAddressCommand createAddress)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createAddress));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAddressCommand deleteAddress)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteAddress));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddress)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateAddress));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetAddressesQuery()));
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
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetAddressQuery getAddressQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getAddressQuery));
        }

        //[HttpGet("getaddressdetail")]
        //public async Task<IActionResult> GetAddressDetail()
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}
    }
}

