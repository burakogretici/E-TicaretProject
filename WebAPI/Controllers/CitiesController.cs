using System.Threading.Tasks;
using Business.Handlers.Cities.Commands;
using Business.Handlers.Cities.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCityCommand createCity)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createCity));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCityCommand deleteCity)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCity));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCity)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCity));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCitiesQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCityQuery getCityQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCityQuery));
        }
    }
}

