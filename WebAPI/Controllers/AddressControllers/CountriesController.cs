using Business.Abstract.AddressService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Countries;

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
        public async Task<IActionResult> Add([FromBody] CountryDto country)
        {
            var result = await _countryService.AddAsync(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Country country)
        {
            var result = await _countryService.DeleteAsync(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Country country)
        {
            var result = await _countryService.UpdateAsync(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _countryService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid countryId)
        {
            var result = await _countryService.GetByIdAsync(countryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
