using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Products.Commands;
using Business.Handlers.Products.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetProductsQuery()));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductQuery getProductQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getProductQuery));
        }

        //[HttpGet("getallbycategorydid")]
        //public async Task<IActionResult> GetAllByCategoryId(Guid categoryId)
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createProduct));
        }

        //[HttpGet("getbyunitprice")]
        //public async Task<IActionResult> GetByUnitPrice(decimal min, decimal max)
        //{
        //    return GetResponseOnlyResultData(await Mediator.Send());
        //}

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProduct)

        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateProduct));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProduct)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteProduct));

        }
    }
}