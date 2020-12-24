using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebPlataformBlazor.Src.Code.Interfaces;
using WebPlataformBlazor.Src.Code.Models;
using WebPlataformBlazor.Src.Code.Services;
using Xunit;

namespace WebPlataformBlazorTeste
{
    public class CategoryServiceTeste
    {
        private readonly ICategoryService _categoryService;

        private readonly ILogger<CategoryService> _logger = LoggerFactory.Create(l => Console.WriteLine())
            .CreateLogger<CategoryService>();

        public CategoryServiceTeste()
        {
            _categoryService = new CategoryService(new HttpClient(),_logger);
        }

        [Fact]
        public async Task TestaCreate()
        {
            var category = new Category()
            {
                Name = "Nome de teste",
                Description = "DescricaoTeste"                
            };
            var response = await _categoryService.Create(category);
            Assert.NotNull(response);


        }

    }
}
