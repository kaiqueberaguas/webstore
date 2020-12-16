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
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly ILogger _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<PageablePresenter<CategoryPresenter>>> Get([FromQuery] int page = 1, [FromQuery] int size = 15)
        {

            var result = await _categoryService.GetAll(page, size);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            var categories = new PageablePresenter<CategoryPresenter>(page, result.TotalPages);
            result.ForEach(r => categories.Content.Add(new CategoryPresenter(r)));
            return categories;
        }

        [AllowAnonymous]
        [HttpGet("{categoryCode}")]
        public async Task<ActionResult<CategoryPresenter>> Get([FromRoute] long categoryCode)
        {
            var result = await _categoryService.Get(categoryCode);
            if (result is null)
            {
                return NotFound();
            }
            return new CategoryPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryPresenter>> Post([FromBody] CategoryCreateParameter category)
        {
            var result = await _categoryService.Create(category.ToModel());
            return CreatedAtAction(nameof(Get), new { categoryCode = result.Code }, new CategoryPresenter(result));
        }

        [HttpPut("{categoryCode}")]
        public async Task<ActionResult<CategoryPresenter>> Put([FromBody] CategoryParameter category, long categoryCode)
        {
            var result = await _categoryService.Update(categoryCode, category.ToModel());
            if (result is null) return NoContent();
            return new CategoryPresenter(result);
        }

        [HttpDelete("{categoryCode}")]
        public async Task<ActionResult<CategoryPresenter>> Delete(long categoryCode)
        {
            var result = await _categoryService.Delete(categoryCode);
            if (result is null) return NotFound();
            return new CategoryPresenter(result);
        }
    }
}
