using Entities.Dtos.Cities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;
using Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Dtos.Countries;

namespace Web.Controllers
{
    public class CitiesController : BaseController
    {
        public CitiesController(IHttpClient httpClient) : base(httpClient) { }

        [HttpGet("city/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var cities = await _httpClient.GetAsync<List<City_VM>>($"cities/getall{tableGlobalFilter.ToQueryString()}");
            return cities.ToGridResult(tableGlobalFilter);
        }
        [HttpGet("city/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var city = await _httpClient.GetAsync<CityDto>($"cities/{id}");
            return View(city.Data);

        }
        public async Task<IActionResult> Create()
        {
            var countries = await _httpClient.GetAsync<List<CountryDto>>("countries/get");
            ViewBag.Countries = new SelectList(countries.Data, "Id", "Name");

            return View();
        }

        [HttpPost("city/create")]
        public async Task<IActionResult> Create(CityDto cityDto)
        {
            var result = await _httpClient.PostAsync<CityDto>("cities/add", cityDto);
            return result.ToJson("/city/index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var city = await _httpClient.GetAsync<CityDto>($"cities/{id}");
            return View(city.Data);
        }

        [HttpPost("city/update")]
        public async Task<IActionResult> Update(CityDto cityDto)
        {
            var result = await _httpClient.PutAsync<CityDto>("cities/update", cityDto);
            return result.ToJson("/city/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<CityDto>($"cities/delete/{id}");
            return result.ToJson();
        }
    }
}
