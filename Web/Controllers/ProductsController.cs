using Entities.Dtos.Brands;
using Entities.Dtos.Categories;
using Entities.Dtos.Colors;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;
using Web.Models;

namespace Web.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IHttpClient httpCient) : base(httpCient) { }

        [HttpGet("product/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var products = await _httpClient.GetAsync<List<ProductList_VM>>($"products/getall{tableGlobalFilter.ToQueryString()}");
            return products.ToGridResult(tableGlobalFilter);
        }

        [HttpGet("product/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _httpClient.GetAsync<ProductDto>($"products/{id}");
            return View(product.Data);
        }

        public async Task<IActionResult> Create()
        {
            await SetProperties();
            return View();
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var result = await _httpClient.PostAsync<ProductDto>("products/add", productDto);
            return result.ToJson("/product/index");
            //if (imageFile != null && imageFile.Length > 0)
            //{
            //    //var imageResult = await _fileService.SaveFile(imageFile.OpenReadStream(), "products", System.IO.Path.GetFileName(imageFile.FileName));
            //    //if (imageResult.HasError)
            //    //{
            //    //    return imageResult.ToJson();
            //    //}
            //    //entity.Image = imageResult.Data;
            //}
        }

        //[HttpGet("product/update")]
        public async Task<IActionResult> Update(string id)
        {
            var result = await _httpClient.GetAsync<ProductDto>($"products/{id}");
            if (result.Data == null)
            {
                return NotFound(result.Message);
            }
            await SetProperties();
            return View(result.Data);
        }

        [HttpPost("product/update")]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            var result = await _httpClient.PutAsync<ProductDto>("products/update", productDto);
            return result.ToJson("/product/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<ProductDto>($"products/delete/{id}");
            return result.ToJson();
        }

        private async Task SetProperties()
        {
            var brands = await _httpClient.GetAsync<List<BrandDto>>("brands/get");
            ViewBag.Brands = new SelectList(brands.Data, "Id", "Name");

            var categories = await _httpClient.GetAsync<List<CategoryDto>>("categories/getall");
            ViewBag.Categories = new SelectList(categories.Data, "Id", "Name");

            var colors = await _httpClient.GetAsync<List<ColorDto>>("colors/getall");
            ViewBag.Colors = new SelectList(colors.Data, "Id", "Name");
        }
    }
}
