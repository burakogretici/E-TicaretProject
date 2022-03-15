using Business.Abstract.AddressService;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.DTOs.Cities;


namespace WebAPI.Controllers.AddressControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CityDto city)
        {
            var result = await _cityService.AddAsync(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] City city)
        {
            var result = await _cityService.DeleteAsync(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] City city)
        {
            var result = await _cityService.UpdateAsync(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cityService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid cityId)
        {
            var result = await _cityService.GetByIdAsync(cityId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

