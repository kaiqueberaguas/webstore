using System;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiProdutos.Src.Controllers.Parameters;
using WebApiProdutos.Src.Interfaces.Services;
using WebApiProdutos.Src.Presenters;

namespace WebApiProdutos.Src.Controllers
{
    [Route("api/v1/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ILogger _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("subcategory/{subcategoryCode}")]
        public async Task<ActionResult<PageablePresenter<ProductPresenter>>> Get(long subcategoryCode, [FromQuery] int page = 1, [FromQuery] int size = 15)
        {
            try
            {
                var result = await _productService.GetBySubcategory(subcategoryCode, page, size);
                if (result.IsNullOrEmpty())
                {
                    return NotFound();
                }
                var products = new PageablePresenter<ProductPresenter>(result.PageIndex, result.TotalPages);
                result.ForEach(r => products.Content.Add(new ProductPresenter(r)));
                return products;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{productCode}")]
        public async Task<ActionResult<ProductPresenter>> Get(long productCode)
        {
            var result = await _productService.Get(productCode);
            if (result is null)
            {
                return NotFound();
            }
            return new ProductPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductPresenter>> Post([FromBody] ProductCreateParameter product)
        {
            var result = await _productService.Create(product.ToModel());
            return CreatedAtAction(nameof(Get), new { productCode = result.Code }, new ProductPresenter(result));
        }

        [HttpPut("{productCode}")]
        public async Task<ActionResult<ProductPresenter>> Put([FromBody] ProductParameter product, long productCode)
        {
            var result = await _productService.Update(productCode, product.ToModel());
            if (result is null) return NotFound();
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
