using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Products.Commands;
using Business.Handlers.Products.Queries;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Business.Handlers.Orders.Commands;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Business.Handlers.Brands.Queries;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<ProductListDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] TableGlobalFilter tableGlobalFilter)
        {
            GetProductsTableQuery getProductsQuery = new() { TableGlobalFilter = tableGlobalFilter };
            return GetResponseOnlyResult(await Mediator.Send(getProductsQuery));
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductListDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            GetProductsQuery getProductsQuery = new() { }; ;
            return GetResponseOnlyResult(await Mediator.Send(getProductsQuery));
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductQuery getProductQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getProductQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProduct)
        {
            return GetResponseOnlyResult(await Mediator.Send(createProduct));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProduct)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateProduct));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand deleteProduct)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteProduct));

        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommand uploadProductImageCommand)
        {
            uploadProductImageCommand.Files = Request.Form.Files;
            return GetResponseOnlyResult(await Mediator.Send(uploadProductImageCommand));
         
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