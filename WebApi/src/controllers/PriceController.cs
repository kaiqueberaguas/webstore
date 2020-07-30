﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.src.controllers.parameters;
using webApi.src.interfaces.services;
using webApi.src.parameters;
using WebApi.src.presenters;

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
        [Produces("application/json")]
        public async Task<IEnumerable<PricePresenter>> Get([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            var prices = new List<PricePresenter>();
            var result = await _priceService.GetAll(page, size);
            result.ForEach(r => prices.Add(new PricePresenter(r)));
            return prices;
        }

        [HttpGet("{priceId}")]
        [Produces("application/json")]
        public async Task<PricePresenter> Get(long priceId)
        {
            var result = await _priceService.Get(priceId);
            return new PricePresenter(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task Post([FromBody] PriceCreateParameter price)
        {
            await _priceService.Create(price.ToModel());
        }

        [HttpPut]
        [Consumes("application/json")]
        public async Task Put([FromBody] PriceParameter price)
        {
            await _priceService.Update(price.ToModel());
        }

        [HttpDelete("{priceId}")]
        public async Task Delete(long priceId)
        {
            await _priceService.Delete(priceId);
        }
    }
}
