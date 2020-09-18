using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi.src.controllers.parameters;
using webApi.src.interfaces.services;
using WebApi.src.presenters;
using WebApi.Src.Models;
using WebApi.Src.Presenters;

namespace webApi.src.controllers
{
    [Route("api/v1/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    // [Authorize("Bearer")]
    // [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet("subcategory/{subcategoryCode}")]
        public async Task<ActionResult<PageablePresenter<ProductPresenter>>> Get(long subcategoryCode, [FromQuery] int page = 1, [FromQuery] int size = 15)
        {
            var result = await _productService.GetAll(page, size, subcategoryCode);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            var products = new PageablePresenter<ProductPresenter>(result.PageIndex,result.TotalPages);
            result.ForEach(r => products.Content.Add(new ProductPresenter(r)));
            return products;
        }

        [AllowAnonymous]
        [HttpGet("{productCode}")]
        public async Task<ActionResult<ProductPresenter>> Get(long productCode)
        {
            var result = await _productService.Get(productCode);
            if (result is null) return NotFound();
            return new ProductPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductPresenter>> Post([FromBody] ProductCreateParameter product)
        {
            var result = await _productService.Create(product.ToModel());
            return CreatedAtAction(nameof(Get), new { productCode = result.Code }, new ProductPresenter(result));
        }

        [HttpPut]
        public async Task<ActionResult<ProductPresenter>> Put([FromBody] ProductParameter product)
        {
            var result = await _productService.Update(product.ToModel());
            if (result is null) return NoContent();
            return new ProductPresenter(result);
        }

        [HttpDelete("{productCode}")]
        public async Task<ActionResult<ProductPresenter>> Delete(long productCode)
        {
            var result = await _productService.Delete(productCode);
            if (result is null) return NotFound();
            return new ProductPresenter(result);
        }
    }
}
