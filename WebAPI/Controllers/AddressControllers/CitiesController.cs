using Business.Abstract.AddressService;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers.AddressControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("add")]
        public IActionResult Add(City city)
        {
            var result = _cityService.Add(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(City city)
        {
            var result = _cityService.Delete(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(City city)
        {
            var result = _cityService.Update(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cityService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int cityId)
        {
            var result = _cityService.GetById(cityId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

