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
    public class SubcategoryController : ControllerBase
    {

        private readonly ISubcategoryService _subcategoryService;
        private ILogger _logger;

        public SubcategoryController(ISubcategoryService subcategoryService, ILogger<SubcategoryController> logger)
        {
            _logger = logger;
            _subcategoryService = subcategoryService;
        }

        [AllowAnonymous]
        [HttpGet("category/{categoryCode}")]
        public async Task<ActionResult<PageablePresenter<SubcategoryPresenter>>> Get(long categoryCode, [FromQuery] int page = 1, [FromQuery] int size = 15)
        {
            try
            {
                var result = await _subcategoryService.GetAllByCategory(categoryCode, page, size);
                if (result.IsNullOrEmpty())
                {
                    return NotFound();
                }
                var subcategories = new PageablePresenter<SubcategoryPresenter>(page, result.TotalPages);
                result.ForEach(r => subcategories.Content.Add(new SubcategoryPresenter(r)));
                return subcategories;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{subcategoryCode}")]
        public async Task<ActionResult<SubcategoryPresenter>> Get(long subcategoryCode)
        {
            var result = await _subcategoryService.Get(subcategoryCode);
            if (result is null)
            {
                return NotFound();
            }
            return new SubcategoryPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<SubcategoryPresenter>> Post([FromBody] SubcategoryCreateParameter subcategory)
        {
            var result = await _subcategoryService.Create(subcategory.ToModel());
            return CreatedAtAction(nameof(Get), new { subcategoryCode = result.Code }, new SubcategoryPresenter(result));
        }

        [HttpPut("{subcategoryCode}")]
        public async Task<ActionResult<SubcategoryPresenter>> Put([FromBody] SubcategoryParameter subcategory, long subcategoryCode)
        {
            var result = await _subcategoryService.Update(subcategoryCode, subcategory.ToModel());
            if (result is null) return NotFound();
            return new SubcategoryPresenter(result);
        }

        [HttpDelete("{subcategoryCode}")]
        public async Task<ActionResult<SubcategoryPresenter>> Delete(long subcategoryCode)
        {
            var result = await _subcategoryService.Delete(subcategoryCode);
            if (result is null) return NotFound();
            return new SubcategoryPresenter(result);
        }
    }
}
