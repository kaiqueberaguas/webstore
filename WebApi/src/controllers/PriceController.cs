using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace webApi.src.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {

        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Price>> Get([FromQuery] int page, [FromQuery] int size)
        {
            return await _priceService.GetAll(page, size);
        }

        [HttpGet("{priceId}")]
        public async Task<Price> Get(long priceId)
        {
            return await _priceService.Get(priceId);
        }

        [HttpPost]
        public async Task Post([FromBody] Price price)
        {
            await _priceService.Create(price);
        }

        [HttpPut]
        public async Task Put([FromBody] Price price)
        {
            await _priceService.Update(price);
        }

        [HttpDelete("{priceId}")]
        public async Task Delete(long priceId)
        {
            await _priceService.Delete(priceId);
        }
    }
}
