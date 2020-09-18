using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class SubcategoryController : ControllerBase
    {

        private readonly ISubcategoryService _subcategoryService;
        private ILogger<SubcategoryController> _logger;

        public SubcategoryController(ISubcategoryService subcategoryService,ILogger<SubcategoryController> logger)
        {
            _logger = logger;
            _subcategoryService = subcategoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<PageablePresenter<SubcategoryPresenter>>> Get([FromQuery] int page = 1, [FromQuery] int size = 15)
        {
            var result = await _subcategoryService.GetAll(page, size);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }
            var subcategories = new PageablePresenter<SubcategoryPresenter>(page, result.TotalPages);
            result.ForEach(r => subcategories.Content.Add(new SubcategoryPresenter(r)));
            return subcategories;
        }

        [AllowAnonymous]
        [HttpGet("{subcategory-code}")]
        public async Task<ActionResult<SubcategoryPresenter>> Get(long subcategoryCode)
        {
            var result = await _subcategoryService.Get(subcategoryCode);
            if (result is null) return NotFound();
            return new SubcategoryPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<SubcategoryPresenter>> Post([FromBody] SubcategoryCreateParameter subcategory)
        {
            
            var result = await _subcategoryService.Create(subcategory.ToModel());
            return CreatedAtAction(nameof(Get), new { subcategoryId = result.Code }, new SubcategoryPresenter(result));
        }

        [HttpPut]
        public async Task<ActionResult<SubcategoryPresenter>> Put([FromBody] SubcategoryParameter subcategory)
        {
            var result = await _subcategoryService.Update(subcategory.ToModel());
            if (result is null) return NoContent();
            return new SubcategoryPresenter(result);
        }

        // [HttpDelete("{subcategoryId}")]
        // public async Task<ActionResult<SubcategoryPresenter>> Delete(long subcategoryId)
        // {
        //     var result = await _subcategoryService.Delete(subcategoryId);
        //     if (result is null) return NotFound();
        //     return new SubcategoryPresenter(result);
        // }
    }
}
