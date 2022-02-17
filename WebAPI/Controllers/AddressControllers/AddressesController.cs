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
        public async Task<IActionResult> GetAll()
        {
            var result = await _addressService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbycountryid")]
        public async Task<IActionResult> GetAllByCountryId(int countryId)
        {
            var result = await _addressService.GetAllByCountryIdAsync(countryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getallbycityid")]
        public async Task<IActionResult> GetAllByCityId(int cityId)
        {
            var result = await _addressService.GetAllByCityIdAsync(cityId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbyuserid")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var result = await _addressService.GetAllByUserIdAsync(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int addressId)
        {
            var result = await _addressService.GetByIdAsync(addressId);
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

