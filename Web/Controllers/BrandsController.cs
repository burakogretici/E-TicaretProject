using Business.Handlers.Brands.Commands;
using Business.Handlers.Brands.Queries;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos.Brands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Web.ApiHelper;

namespace Web.Controllers
{

    public class BrandsController : Controller
    {
        private readonly IApiHelper _apiHelper;

        public BrandsController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {

            var brands = await _apiHelper.Get<BrandDto>("brands/getall");
            return View(brands);

        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {

            var brand = await _apiHelper.GetById<BrandDto>($"brands/{id}");
            return View(brand);

        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BrandDto brandDto)
        {

            await _apiHelper.Post<BrandDto>("brands/add", brandDto);

            return RedirectToAction("getall");
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update(string id)
        {
            var brand = await _apiHelper.GetById<BrandDto>($"brands/{id}");
            return View(brand);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            await _apiHelper.Put<BrandDto>("brands/update", brandDto);
            return RedirectToAction("getall");
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _apiHelper.Delete<BrandDto>($"brands/delete/{id}");
            return RedirectToAction("getall");
        }
    }
}




