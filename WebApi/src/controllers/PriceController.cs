using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<PricePresenter>> Get([FromQuery] int page, [FromQuery] int size)
        {
            var prices = new List<PricePresenter>();
            var result = await _priceService.GetAll(page, size);
            result.ForEach(r => new PricePresenter(r));
            return prices;
        }

        [HttpGet("{priceId}")]
        public async Task<PricePresenter> Get(long priceId)
        {
            var result = await _priceService.Get(priceId);
            return new PricePresenter(result);
        }

        [HttpPost]
        public async Task Post([FromBody] PriceParameter price)
        {
            await _priceService.Create(price.ToModel());
        }

        [HttpPut]
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
