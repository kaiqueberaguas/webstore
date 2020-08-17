using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.src.controllers.parameters;
using webApi.src.interfaces.services;
using WebApi.src.presenters;

namespace webApi.src.controllers
{
    [Route("api/v1/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize("Bearer")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IList<ProductPresenter>>> Get(
            [FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            var products = new List<ProductPresenter>();
            var result = await _productService.GetAll(page, size);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            result.ForEach(r => products.Add(new ProductPresenter(r)));
            return products;
        }

        [AllowAnonymous]
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductPresenter>> Get(long productId)
        {
            var result = await _productService.Get(productId);
            if (result is null) return NotFound();
            return new ProductPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductPresenter>> Post([FromBody] ProductCreateParameter product)
        {
            var result = await _productService.Create(product.ToModel());
            return CreatedAtAction(nameof(Get), new { productId = result.Id }, new ProductPresenter(result));
        }

        [HttpPut]
        public async Task<ActionResult<ProductPresenter>> Put([FromBody] ProductParameter product)
        {
            var result = await _productService.Update(product.ToModel());
            if (result is null) return NoContent();
            return new ProductPresenter(result);
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult<ProductPresenter>> Delete(long productId)
        {
            var result = await _productService.Delete(productId);
            if (result is null) return NotFound();
            return new ProductPresenter(result);
        }
    }
}
