using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.src.controllers.parameters;
using webApi.src.interfaces.services;
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
        [Produces("application/json")]
        public async Task<IEnumerable<ProductPresenter>> Get([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            var products = new List<ProductPresenter>();
            var result = await _productService.GetAll(page,size);
            result.ForEach(r => products.Add(new ProductPresenter(r)));
            return products;
        }

        [HttpGet("{productId}")]
        [Produces("application/json")]
        public async Task<ProductPresenter> Get(long productId)
        {
            var result = await _productService.Get(productId);
            return new ProductPresenter(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task Post([FromBody] ProductCreateParameter product)
        {
            await _productService.Create(product.ToModel());
        }

        [HttpPut]
        [Consumes("application/json")]
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
