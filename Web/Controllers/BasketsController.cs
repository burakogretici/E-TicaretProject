using Entities.Dtos.Baskets;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;
using Web.Models;

namespace Web.Controllers
{
    public class BasketsController : BaseController
    {
        public BasketsController(IHttpClient httpClient) : base(httpClient) { }

        [HttpGet("basket/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var baskets = await _httpClient.GetAsync<List<BasketItem_VM>>($"baskets/get-basketItems{tableGlobalFilter.ToQueryString()}");
            return baskets.ToGridResult(tableGlobalFilter);
        }
        [HttpGet("basket/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var basket = await _httpClient.GetAsync<BasketDto>($"baskets/{id}");
            return View(basket.Data);

        }

        public async Task<IActionResult> Create()
        {
            await SetProperties();
            return View();
        }

        [HttpPost("basket/create")]
        public async Task<IActionResult> Create(BasketItemDto basketDto)
        {
            var result = await _httpClient.PostAsync<BasketItemDto>("baskets/add-basketItem", basketDto);
            return result.ToJson("/basket/index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var basket = await _httpClient.GetAsync<BasketDto>($"baskets/{id}");
            return View(basket.Data);
        }

        [HttpPost("basket/update")]
        public async Task<IActionResult> Update(BasketDto basketDto)
        {
            var result = await _httpClient.PutAsync<BasketDto>("baskets/update", basketDto);
            return result.ToJson("/basket/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<BasketDto>($"baskets/delete/{id}");
            return result.ToJson();
        }
        private async Task SetProperties()
        {
            var products = await _httpClient.GetAsync<List<ProductDto>>("products/get");
            ViewBag.Products = new SelectList(products.Data, "Id", "Name");

            var baskets = await _httpClient.GetAsync<List<BasketListDto>>("baskets/getall");
            ViewBag.Baskets = new SelectList(baskets.Data, "Id", "CustomerName");



        }
    }
}
