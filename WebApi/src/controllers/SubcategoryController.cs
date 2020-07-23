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
    public class SubcategoryController : ControllerBase
    {

        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<SubcategoryPresenter>> Get([FromQuery] int page, [FromQuery] int size)
        {
            var subcategories = new List<SubcategoryPresenter>();
            var result = await _subcategoryService.GetAll(page,size);
            result.ForEach(r => new SubcategoryPresenter(r));
            return subcategories;

        }

        [HttpGet("{subcategoryId}")]
        [Produces("application/json")]
        public async Task<SubcategoryPresenter> Get(long subcategoryId)
        {
            var result = await _subcategoryService.Get(subcategoryId);
            return new SubcategoryPresenter(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task Post([FromBody] SubcategoryCreateParameter subcategory)
        {
            await _subcategoryService.Create(subcategory.ToModel());
        }

        [HttpPut]
        [Consumes("application/json")]
        public async Task Put([FromBody] SubcategoryParameter subcategory)
        {
            await _subcategoryService.Update(subcategory.ToModel());
        }

        [HttpDelete("{subcategoryId}")]
        public async Task Delete(long subcategoryId)
        {
            await _subcategoryService.Delete(subcategoryId);
        }
    }
}
