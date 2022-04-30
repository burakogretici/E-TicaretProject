using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Categories.Commands;
using Business.Handlers.Categories.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return GetResponseOnlyResultData(await Mediator.Send(new GetCategoriesQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryQuery getCategoryQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCategoryQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategory)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createCategory));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategory)

        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCategory));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategory)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCategory));
        }
    }
}
