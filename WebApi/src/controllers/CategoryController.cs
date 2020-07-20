using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.src.interfaces.services;
using webApi.src.parameters;
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
        public async Task Post([FromBody] CategoryParameter category)
        {
            await _categoryService.Create(category.ToModel());
        }

        [HttpPut]
        public async Task Put([FromBody] CategoryParameter category)
        {
            await _categoryService.Update(category.ToModel());
        }

        [HttpDelete("{categoryId}")]
        public async Task Delete(long categoryId)
        {
            await _categoryService.Delete(categoryId);
        }
    }
}
