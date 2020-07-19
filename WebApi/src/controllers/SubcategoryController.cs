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
    public class SubcategoryController : ControllerBase
    {

        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Subcategory>> Get([FromQuery] int page, [FromQuery] int size)
        {
            return await _subcategoryService.GetAll(page,size);
        }

        [HttpGet("{subcategoryId}")]
        public async Task<Subcategory> Get(long subcategoryId)
        {
            return await _subcategoryService.Get(subcategoryId);
        }

        [HttpPost]
        public async Task Post([FromBody] Subcategory subcategory)
        {
            await _subcategoryService.Create(subcategory);
        }

        [HttpPut]
        public async Task Put([FromBody] Subcategory subcategory)
        {
            await _subcategoryService.Update(subcategory);
        }

        [HttpDelete("{subcategoryId}")]
        public async Task Delete(long subcategoryId)
        {
            await _subcategoryService.Delete(subcategoryId);
        }
    }
}
