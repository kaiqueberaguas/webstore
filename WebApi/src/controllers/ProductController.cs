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
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductPresenter>> Get([FromQuery] int page, [FromQuery] int size)
        {
            var products = new List<ProductPresenter>();
            var result = await _productService.GetAll(page,size);
            result.ForEach(r => new ProductPresenter(r));
            return products;
        }

        [HttpGet("{productId}")]
        public async Task<ProductPresenter> Get(long productId)
        {
            var result = await _productService.Get(productId);
            return new ProductPresenter(result);
        }

        [HttpPost]
        public async Task Post([FromBody] ProductParameter product)
        {
            await _productService.Create(product.ToModel());
        }

        [HttpPut]
        public async Task Put([FromBody] ProductParameter product)
        {
            await _productService.Update(product.ToModel());
        }

        [HttpDelete("{productId}")]
        public async Task Delete(long productId)
        {
            await _productService.Delete(productId);
        }
    }
}
