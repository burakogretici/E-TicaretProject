using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Cities.Commands;
using Business.Handlers.Cities.Queries;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Cities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController
    {

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<CityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetTableSearch([FromQuery] TableGlobalFilter tableGlobalFilter)
        {
            GetCitiesTableQuery getCitiesTableQuery = new() { TableGlobalFilter = tableGlobalFilter };
            return GetResponseOnlyResult(await Mediator.Send(getCitiesTableQuery));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCityCommand createCity)
        {
            return GetResponseOnlyResult(await Mediator.Send(createCity));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCityCommand deleteCity)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteCity));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCity)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateCity));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResult(await Mediator.Send(new GetCitiesQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("delete/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCityQuery getCityQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getCityQuery));
        }
    }
}

