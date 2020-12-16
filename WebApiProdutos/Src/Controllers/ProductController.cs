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
    // [Authorize("Bearer")]
    // [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
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
            var products = new PageablePresenter<ProductPresenter>(result.PageIndex, result.TotalPages);
            result.ForEach(r => products.Content.Add(new ProductPresenter(r)));
            _logger.LogInformation($"Total de registros retornados:{products.Content.Count}");
            return products;
        }

        [AllowAnonymous]
        [HttpGet("{productCode}")]
        public async Task<ActionResult<ProductPresenter>> Get(long productCode)
        {
            var result = await _productService.Get(productCode);
            if (result is null)
            {
                _logger.LogInformation($"Produto não encontrado, codigo:{productCode}");
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

        //[HttpPut]
        //public async Task<ActionResult<ProductPresenter>> Put([FromBody] ProductParameter product)
        //{
        //    var result = await _productService.Update(product.ToModel());
        //    if (result is null) return NoContent();
        //    return new ProductPresenter(result);
        //}

        [HttpDelete("{productCode}")]
        public async Task<ActionResult<ProductPresenter>> Delete(long productCode)
        {
            var result = await _productService.Delete(productCode);
            if (result is null) return NotFound();
            return new ProductPresenter(result);
        }
    }
}
