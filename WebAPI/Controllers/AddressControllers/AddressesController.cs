using Business.Abstract.AddressService;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;

namespace WebAPI.Controllers.AddressControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        readonly IAddressService _addressService;
        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddressDto address)
        {
            var result = _addressService.Add(address);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Address address)
        {
            var result = _addressService.Delete(address);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Address address)
        {
            var result = _addressService.Update(address);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _addressService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbycountryid")]
        public IActionResult GetAllByCountryId(int countryId)
        {
            var result = _addressService.GetAllByCountryId(countryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getallbycityid")]
        public IActionResult GetAllByCityId(int cityId)
        {
            var result = _addressService.GetAllByCityId(cityId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _addressService.GetAllByUserId(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int addressId)
        {
            var result = _addressService.GetById(addressId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getaddressdetail")]
        public IActionResult GetAddressDetail()
        {
            var result = _addressService.GetAddressDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

