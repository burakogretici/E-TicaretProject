using System.Threading.Tasks;
using Business.Handlers.Countries.Commands;
using Business.Handlers.Countries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCountryCommand countryCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(countryCommand));

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCountryCommand deleteCountry)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCountry));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCountryCommand updateCountry)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCountry));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCountriesQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCountryQuery getCountryQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCountryQuery));
        }
    }
}