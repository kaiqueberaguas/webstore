using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.src.interfaces.services;
using webApi.src.models;
using WebApi.src.presenters;

namespace webApi.src.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<CategoryPresenter>> Get([FromQuery]int page, [FromQuery] int size)
        {
            var categories = new List<CategoryPresenter>();
            var result = await _categoryService.GetAll(page,size);
            result.ForEach(r => new CategoryPresenter(r));
            return categories;
        }

        [HttpGet("{categoryId}")]
        public async Task<CategoryPresenter> Get(long categoryId)
        {
            var result = await _categoryService.Get(categoryId);
            return new CategoryPresenter(result);
        }

        [HttpPost]
        public async Task Post([FromBody] Category category)
        {
            await _categoryService.Create(category);
        }

        [HttpPut]
        public async Task Put([FromBody] Category category)
        {
            await _categoryService.Update(category);
        }

        [HttpDelete("{categoryId}")]
        public async Task Delete(long categoryId)
        {
            await _categoryService.Delete(categoryId);
        }
    }
}
