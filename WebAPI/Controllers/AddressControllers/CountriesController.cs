using Business.Abstract.AddressService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers.AddressControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("add")]
        public IActionResult Add(CountryDto country)
        {
            var result = _countryService.Add(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Country country)
        {
            var result = _countryService.Delete(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Country country)
        {
            var result = _countryService.Update(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _countryService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int countryId)
        {
            var result = await _countryService.GetByIdAsync(countryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
