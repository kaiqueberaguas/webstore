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
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get([FromQuery] int page, [FromQuery] int size)
        {
            return await _productService.GetAll(page,size);
        }

        [HttpGet("{productId}")]
        public async Task<Product> Get(long productId)
        {
            return await _productService.Get(productId);
        }

        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _productService.Create(product);
        }

        [HttpPut]
        public async Task Put([FromBody] Product product)
        {
            await _productService.Update(product);
        }

        [HttpDelete("{productId}")]
        public async Task Delete(long productId)
        {
            await _productService.Delete(productId);
        }
    }
}
