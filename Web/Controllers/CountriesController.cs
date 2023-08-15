using Entities.Dtos.Countries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;
using Web.Models;

namespace Web.Controllers
{
    public class CountriesController : BaseController
    {
        public CountriesController(IHttpClient httpClient) : base(httpClient) { }

        [HttpGet("country/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var Countries = await _httpClient.GetAsync<List<Country_VM>>($"countries/getall{tableGlobalFilter.ToQueryString()}");
            return Countries.ToGridResult(tableGlobalFilter);
        }
        [HttpGet("country/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var country = await _httpClient.GetAsync<CountryDto>($"countries/{id}");
            return View(country.Data);

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("country/create")]
        public async Task<IActionResult> Create(CountryDto countryDto)
        {
            var result = await _httpClient.PostAsync<CountryDto>("countries/add", countryDto);
            return result.ToJson("/country/index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var country = await _httpClient.GetAsync<CountryDto>($"countries/{id}");
            return View(country.Data);
        }

        [HttpPost("country/update")]
        public async Task<IActionResult> Update(CountryDto countryDto)
        {
            var result = await _httpClient.PutAsync<CountryDto>("countries/update", countryDto);
            return result.ToJson("/country/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<CountryDto>($"countries/delete/{id}");
            return result.ToJson();
        }
    }
}
