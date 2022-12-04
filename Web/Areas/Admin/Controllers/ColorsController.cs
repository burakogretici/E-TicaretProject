using Entities.Dtos.Colors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly IApiHelper _apiHelper;

        public ColorsController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
     
        [HttpGet("color/index")]
        public async Task<IActionResult> Index()
        {
            var colors = await _apiHelper.Get<ColorDto>("colors/getall");
            return View(colors);
        }
        [HttpGet("color/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var color = await _apiHelper.GetById<ColorDto>($"colors/{id}");
            return View(color);

        }

        [HttpGet("color/create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("color/create")]
        public async Task<IActionResult> Create(ColorDto colorDto)
        {

            await _apiHelper.Post<ColorDto>("colors/add", colorDto);

            return RedirectToAction("Index");
        }

        [HttpGet("color/update")]
        public async Task<IActionResult> Update(string id)
        {
            var color = await _apiHelper.GetById<ColorDto>($"colors/{id}");
            return View(color);
        }

        [HttpPost("color/update")]
        public async Task<IActionResult> Update(ColorDto colorDto)
        {
            await _apiHelper.Put<ColorDto>("colors/update", colorDto);
            return RedirectToAction("Index");
        }

        [HttpGet("color/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _apiHelper.Delete<ColorDto>($"colors/delete/{id}");
            return RedirectToAction("Index");
        }
    }
}
