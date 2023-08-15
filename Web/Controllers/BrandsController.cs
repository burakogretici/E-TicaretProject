using Business.Services;
using Core.Utilities.Paging;
using Core.Utilities.Results;
using Entities.Dtos.Brands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Controllers;
using Web.ApiHelper;
using Entities.Dtos.Products;
using Web.Models;

namespace Web.Controllers
{
    public class BrandsController : BaseController
    {
        public BrandsController(IHttpClient httpClient) : base(httpClient) { }

        [HttpGet("brand/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var brands = await _httpClient.GetAsync<List<Brand_VM>>($"brands/getall{tableGlobalFilter.ToQueryString()}");
            return brands.ToGridResult(tableGlobalFilter);
        }
        [HttpGet("brand/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var brand = await _httpClient.GetAsync<BrandDto>($"brands/{id}");
            return View(brand.Data);

        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("brand/create")]
        public async Task<IActionResult> Create(BrandDto brandDto)
        {
            var result = await _httpClient.PostAsync<BrandDto>("brands/add", brandDto);
            return result.ToJson("/brand/index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var brand = await _httpClient.GetAsync<BrandDto>($"brands/{id}");
            return View(brand.Data);
        }

        [HttpPost("brand/update")]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            var result = await _httpClient.PutAsync<BrandDto>("brands/update", brandDto);
            return result.ToJson("/brand/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<BrandDto>($"brands/delete/{id}");
            return result.ToJson();
        }
    }
}
