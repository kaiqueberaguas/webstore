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
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get([FromQuery]int page, [FromQuery] int size)
        {
            return await _categoryService.GetAll(page,size);
        }

        [HttpGet("{categoryId}")]
        public async Task<Category> Get(long categoryId)
        {
            return await _categoryService.Get(categoryId);
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
