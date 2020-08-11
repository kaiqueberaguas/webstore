using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.src.controllers.parameters;
using webApi.src.interfaces.services;
using WebApi.src.presenters;

namespace webApi.src.controllers
{
    [Route("api/v1/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {

        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<SubcategoryPresenter>>> Get(
            [FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            var subcategories = new List<SubcategoryPresenter>();
            var result = await _subcategoryService.GetAll(page, size);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            result.ForEach(r => subcategories.Add(new SubcategoryPresenter(r)));
            return subcategories;
        }

        [HttpGet("{subcategoryId}")]
        public async Task<ActionResult<SubcategoryPresenter>> Get(long subcategoryId)
        {
            var result = await _subcategoryService.Get(subcategoryId);
            if (result is null) return NotFound();
            return new SubcategoryPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<SubcategoryPresenter>> Post([FromBody] SubcategoryCreateParameter subcategory)
        {
            var result = await _subcategoryService.Create(subcategory.ToModel());
            return CreatedAtAction(nameof(Get), new { subcategoryId = result.Id }, new SubcategoryPresenter(result));
        }

        [HttpPut]
        public async Task<ActionResult<SubcategoryPresenter>> Put([FromBody] SubcategoryParameter subcategory)
        {
            var result = await _subcategoryService.Update(subcategory.ToModel());
            if (result is null) return NoContent();
            return new SubcategoryPresenter(result);
        }

        [HttpDelete("{subcategoryId}")]
        public async Task<ActionResult<SubcategoryPresenter>> Delete(long subcategoryId)
        {
            var result = await _subcategoryService.Delete(subcategoryId);
            if (result is null) return NotFound();
            return new SubcategoryPresenter(result);
        }
    }
}
