using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi.src.controllers.parameters;
using webApi.src.interfaces.services;
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
        [Produces("application/json")]
        public async Task<List<CategoryPresenter>> Get([FromQuery]int page, [FromQuery] int size)
        {
            var categories = new List<CategoryPresenter>();
            var result = await _categoryService.GetAll(page,size);
            result.ForEach(r => new CategoryPresenter(r));
            return categories;
        }

        [HttpGet("{categoryId}")]
        [Produces("application/json")]
        public async Task<CategoryPresenter> Get(long categoryId)
        {
            var result = await _categoryService.Get(categoryId);
            return new CategoryPresenter(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task Post([FromBody] CategoryCreateParameter category)
        {
            await _categoryService.Create(category.ToModel());
        }

        [HttpPut]
        [Consumes("application/json")]
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
