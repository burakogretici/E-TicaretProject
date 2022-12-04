using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Products.Commands;
using Business.Handlers.Products.Queries;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetProductsQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductQuery getProductQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getProductQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createProduct));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateProduct));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteProduct));

        }

        //[HttpGet("getbyunitprice")]
        //public async Task<IActionResult> GetByUnitPrice(decimal min, decimal max)
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}
        //[HttpGet("getallbycategorydid")]
        //public async Task<IActionResult> GetAllByCategoryId(Guid categoryId)
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}
    }
}