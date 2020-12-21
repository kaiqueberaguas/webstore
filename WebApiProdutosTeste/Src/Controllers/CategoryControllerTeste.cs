using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using WebApiProdutos.Src.Controllers;
using WebApiProdutos.Src.Controllers.Parameters;
using WebApiProdutos.Src.Models;
using WebApiProdutosTeste.Src.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using WebApiProdutos.Src.Presenters;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace WebApiProdutosTeste.Src.Controllers
{
    public class CategoryControllerTeste
    {
        private readonly CategoryController _controller;
        private readonly CategoryServiceMock _service;
        private readonly ILogger<CategoryController> _logger = LoggerFactory.Create(l => l.AddDebug()).CreateLogger<CategoryController>();

        public CategoryControllerTeste()
        {
            _service = new CategoryServiceMock();
            _controller = new CategoryController(_service, _logger);
        }

        [Theory]
        //[InlineData(1, 15)]
        [InlineData(2, 15)]
        public async Task TestaGetPaginado(int page,int size)
        {
            ActionResult<PageablePresenter<CategoryPresenter>> response = await _controller.Get(page, size);
            if (page == 2)
            {
                Assert.IsType<NoContentResult>(response);
            }
            else 
            {
                Assert.IsType<OkObjectResult>(response);
                Assert.IsType<ActionResult<PageablePresenter<CategoryPresenter>>>(response);
            }
        }
        
        //[Theory]
        //[InlineData(1234)]
        //[InlineData(5667)]
        //public async Task TestaGet(long code)
        //{
        //    var response = await _controller.Get(code);
        //    Assert.IsType<OkObjectResult>(response.Result);
        //    Assert.IsType<ActionResult<CategoryPresenter>>(response);
        //}

        [Fact]
        public async Task TestaCreate()
        {
            var obj = new CategoryCreateParameter()
            {
                Name = "Teste",
                Description = "descrição"
            };
            
            var response = await _controller.Post(obj);

            Assert.IsType<CreatedAtActionResult>(response.Result);
            Assert.IsType<ActionResult<CategoryPresenter>>(response);

        }
    }
}
