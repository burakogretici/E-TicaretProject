using Entities.Dtos.Addresses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web.ApiHelper;
using Web.Models;
using System.Threading.Tasks;
using Entities.Dtos.Cities;
using Entities.Dtos.Countries;
using Entities.Dtos.Users;

namespace Web.Controllers
{
    public class AddressesController : BaseController
    {
        public AddressesController(IHttpClient httpCient) : base(httpCient) { }

        [HttpGet("address/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            //todo 
            var addresses = await _httpClient.GetAsync<List<Address_VM>>($"addresses/getall{tableGlobalFilter.ToQueryString()}");
            return addresses.ToGridResult(tableGlobalFilter);
        }

        [HttpGet("address/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var address = await _httpClient.GetAsync<AddressDto>($"addresses/{id}");
            return View(address.Data);
        }

        public async Task<IActionResult> Create()
        {
            await SetProperties();
            return View();
        }

        [HttpPost("address/create")]
        public async Task<IActionResult> Create(AddressDto addressDto)
        {
            var result = await _httpClient.PostAsync<AddressDto>("addresses/add", addressDto);
            return result.ToJson("/address/index");
 
        }

        public async Task<IActionResult> Update(string id)
        {
            var result = await _httpClient.GetAsync<AddressDto>($"addresses/{id}");
            if (result.Data == null)
            {
                return NotFound(result.Message);
            }
            await SetProperties();
            return View(result.Data);
        }

        [HttpPost("address/update")]
        public async Task<IActionResult> Update(AddressDto addressDto)
        {
            var result = await _httpClient.PutAsync<AddressDto>("addresses/update", addressDto);
            return result.ToJson("/address/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<AddressDto>($"addresses/delete/{id}");
            return result.ToJson();
        }

        private async Task SetProperties()
        {
            var users = await _httpClient.GetAsync<List<UserDto>>("users/getall");
            ViewBag.Users = new SelectList(users.Data, "Id", "FullName");

            var cities = await _httpClient.GetAsync<List<CityDto>>("cities/get");
            ViewBag.Cities = new SelectList(cities.Data, "Id", "Name");

            var countries = await _httpClient.GetAsync<List<CountryDto>>("countries/get");
            ViewBag.Countries = new SelectList(countries.Data, "Id", "Name");

          
        }
    }
}
