using Microsoft.Extensions.Logging;
using WebApiProdutos.Src.Controllers;
using WebApiProdutos.Src.Controllers.Parameters;
using WebApiProdutosTeste.Src.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using WebApiProdutos.Src.Presenters;
using System.Threading.Tasks;

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
        [InlineData(1, 15)]
        [InlineData(2, 15)]
        public async Task TestaGetPaginado(int page, int size)
        {
            var response = await _controller.Get(page, size);
            if (page == 2)
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
            else
            {
                Assert.IsType<ActionResult<PageablePresenter<CategoryPresenter>>>(response);
            }
        }

        [Theory]
        [InlineData(1234)]
        [InlineData(5667)]
        public async Task TestaGet(long code)
        {
            var response = await _controller.Get(code);
            if (code == 1234)
            {
                Assert.IsType<ActionResult<CategoryPresenter>>(response);
            }
            else
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
        }

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

        [Theory]
        [InlineData(1234)]
        [InlineData(5678)]
        public async Task TestaUpdate(long code)
        {
            var category = new CategoryParameter()
            {
                CategoryCode = code,
                Description = "Teste atualizãção",
                IsActive = false,
                Name = "Atualizada"
            };

            var response = await _controller.Put(category,code);
            if (code == 1234)
            {
                Assert.IsType<ActionResult<CategoryPresenter>>(response);
            }
            else
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
        }


        [Theory]
        [InlineData(1234)]
        [InlineData(5678)]
        public async Task TestaDelete(long code)
        {
            var response = await _controller.Delete(code);
            if (code == 1234)
            {
                Assert.IsType<ActionResult<CategoryPresenter>>(response);
            }
            else
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
        }
    }
}
