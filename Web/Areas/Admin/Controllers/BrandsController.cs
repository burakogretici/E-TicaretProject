using Entities.Dtos.Brands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IApiHelper _apiHelper;

        public BrandsController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet("brand/index")]
        public async Task<IActionResult> Index()
        {
            var brands = await _apiHelper.Get<BrandDto>("brands/getall");
            return View(brands);
        }
        [HttpGet("brand/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var brand = await _apiHelper.GetById<BrandDto>($"brands/{id}");
            return View(brand);

        }

        [HttpGet("brand/create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("brand/create")]
        public async Task<IActionResult> Create(BrandDto brandDto)
        {

            await _apiHelper.Post<BrandDto>("brands/add", brandDto);

            return RedirectToAction("Index");
        }

        [HttpGet("brand/update")]
        public async Task<IActionResult> Update(string id)
        {
            var brand = await _apiHelper.GetById<BrandDto>($"brands/{id}");
            return View(brand);
        }

        [HttpPost("brand/update")]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            await _apiHelper.Put<BrandDto>("brands/update", brandDto);
            return RedirectToAction("Index");
        }

        [HttpGet("brand/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _apiHelper.Delete<BrandDto>($"brands/delete/{id}");
            return RedirectToAction("Index");
        }
    }
}
