using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.src.controllers.parameters;
using webApi.src.interfaces.services;
using webApi.src.parameters;
using WebApi.src.presenters;

namespace webApi.src.controllers
{
    [Route("api/v1/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize("Bearer")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class PriceController : ControllerBase
    {

        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IList<PricePresenter>>> Get(
            [FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            var prices = new List<PricePresenter>();
            var result = await _priceService.GetAll(page, size);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            result.ForEach(r => prices.Add(new PricePresenter(r)));
            return prices;
        }

        [AllowAnonymous]
        [HttpGet("{priceId}")]
        public async Task<ActionResult<PricePresenter>> Get(long priceId)
        {
            var result = await _priceService.Get(priceId);
            if (result is null) return NotFound();
            return new PricePresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<PricePresenter>> Post([FromBody] PriceCreateParameter price)
        {
            var result = await _priceService.Create(price.ToModel());
            return CreatedAtAction(nameof(Get), new { categoryId = result.Id }, new PricePresenter(result));
        }

        [HttpPut]
        public async Task<ActionResult<PricePresenter>> Put([FromBody] PriceParameter price)
        {
            var result = await _priceService.Update(price.ToModel());
            if (result is null) return NoContent();
            return new PricePresenter(result);
        }

        [HttpDelete("{priceId}")]
        public async Task<ActionResult<PricePresenter>> Delete(long priceId)
        {
            var result = await _priceService.Delete(priceId);
            if (result is null) return NotFound();
            return new PricePresenter(result);
        }
    }
}
