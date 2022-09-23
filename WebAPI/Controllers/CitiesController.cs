using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Cities.Commands;
using Business.Handlers.Cities.Queries;
using Entities.Dtos.Cities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCityCommand createCity)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createCity));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCityCommand deleteCity)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCity));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCity)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCity));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<CityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCitiesQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(CityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("delete/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCityQuery getCityQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCityQuery));
        }
    }
}

