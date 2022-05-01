using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Brands.Commands;
using Business.Handlers.Brands.Queries;
using Entities.Dtos.Brands;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
     
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetBrandsQuery()));
        }

       
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBrandQuery getBrandQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getBrandQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createBrand));
        }
        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateBrand));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteBrand));
        }

    }

}
