using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Countries.Commands;
using Business.Handlers.Countries.Queries;
using Entities.Dtos.Countries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCountryCommand countryCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(countryCommand));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCountryCommand deleteCountry)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCountry));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCountryCommand updateCountry)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCountry));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<CountryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCountriesQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(CountryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("delete/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCountryQuery getCountryQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCountryQuery));
        }
    }
}