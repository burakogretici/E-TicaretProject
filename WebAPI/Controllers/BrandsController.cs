using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Brands.Commands;
using Business.Handlers.Brands.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetBrandsQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBrandQuery getBrandQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getBrandQuery));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createBrand));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateBrand));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteBrand));
        }

    }

}
