using System;
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
    //[Authorize("Bearer")]
    //[Authorize(Roles = "ADMIN")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryPresenter>> Get([FromRoute] long categoryId)
        {
            var result = await _categoryService.Get(categoryId);
            if (result is null) return NotFound();
            return new CategoryPresenter(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryPresenter>> Post([FromBody] CategoryCreateParameter category)
        {
            var result = await _categoryService.Create(category.ToModel());
            return CreatedAtAction(nameof(Get), new { categoryId = result.Id }, new CategoryPresenter(result));
        }

        [HttpPut]
        public async Task<ActionResult<CategoryPresenter>> Put([FromBody] CategoryParameter category)
        {
            var result = await _categoryService.Update(category.ToModel());
            if (result is null) return NoContent();
            return new CategoryPresenter(result);
        }

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult<CategoryPresenter>> Delete(long categoryId)
        {
            var result = await _categoryService.Delete(categoryId);
            if (result is null) return NotFound();
            return new CategoryPresenter(result);
        }
    }
}
