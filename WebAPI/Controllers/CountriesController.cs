using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Countries.Commands;
using Business.Handlers.Countries.Queries;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Countries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<CountryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetTableSearch([FromQuery] TableGlobalFilter tableGlobalFilter)
        {
            GetCountriesTableQuery getCountriesQuery = new() { TableGlobalFilter = tableGlobalFilter };
            return GetResponseOnlyResult(await Mediator.Send(getCountriesQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateCountryCommand countryCommand)
        {
            return GetResponseOnlyResult(await Mediator.Send(countryCommand));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCountryCommand deleteCountry)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteCountry));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCountryCommand updateCountry)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateCountry));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CountryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResult(await Mediator.Send(new GetCountriesQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(CountryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("delete/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCountryQuery getCountryQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getCountryQuery));
        }
    }
}