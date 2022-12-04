using Entities.Dtos.Brands;
using Entities.Dtos.Categories;
using Entities.Dtos.Colors;
using Entities.Dtos.Menus;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IApiHelper _apiHelper;

        public ProductsController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet("product/index")]
        public async Task<IActionResult> Index()
        {
            var products = await _apiHelper.Get<ProductDto>("products/getall");
            return View(products);
        }
        [HttpGet("product/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _apiHelper.GetById<ProductDto>($"products/{id}");
            return View(product);

        }

        [HttpGet("product/create")]
        public async Task<IActionResult> Create()
        {
            var brands = await _apiHelper.Get<BrandDto>("brands/getall");
            ViewBag.Brands = new SelectList(brands, "Id", "Name");

            var categories = await _apiHelper.Get<CategoryDto>("categories/getall");
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var colors = await _apiHelper.Get<ColorDto>("colors/getall");
            ViewBag.Colors = new SelectList(colors, "Id", "Name");

            return View();
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _apiHelper.Post<ProductDto>("products/add", productDto);

            return RedirectToAction("Index");
        }

        [HttpGet("product/update")]
        public async Task<IActionResult> Update(string id)
        {
            var brands = await _apiHelper.Get<BrandDto>("brands/getall");
            ViewBag.Brands = new SelectList(brands, "Id", "Name");

            var categories = await _apiHelper.Get<CategoryDto>("categories/getall");
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var colors = await _apiHelper.Get<ColorDto>("colors/getall");
            ViewBag.Colors = new SelectList(colors, "Id", "Name");

            var product = await _apiHelper.GetById<ProductDto>($"products/{id}");
            return View(product);
        }

        [HttpPost("product/update")]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _apiHelper.Put<ProductDto>("products/update", productDto);
            return RedirectToAction("Index");
        }

        [HttpGet("product/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _apiHelper.Delete<ProductDto>($"products/delete/{id}");
            return RedirectToAction("Index");
        }
    }
}
