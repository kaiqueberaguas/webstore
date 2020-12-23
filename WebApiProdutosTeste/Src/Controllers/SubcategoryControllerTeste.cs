using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApiProdutos.Src.Controllers;
using WebApiProdutos.Src.Controllers.Parameters;
using WebApiProdutos.Src.Presenters;
using WebApiProdutosTeste.Src.Mock;
using Xunit;

namespace WebApiProdutosTeste.Src.Controllers
{
    public class SubcategoryControllerTeste
    {
        private readonly SubcategoryController _controller;
        private readonly SubcategoryServiceMock _service;
        private readonly ILogger<SubcategoryController> _logger = LoggerFactory.Create(l => l.AddDebug()).CreateLogger<SubcategoryController>();

        public SubcategoryControllerTeste()
        {
            _service = new SubcategoryServiceMock();
            _controller = new SubcategoryController(_service, _logger);
        }

        [Theory]
        [InlineData(1234, 1, 15)]
        [InlineData(1234, 2, 15)]
        [InlineData(5678, 1, 15)]
        public async Task TestaGetPaginado(long categoryCode, int page, int size)
        {
            var response = await _controller.Get(categoryCode, page, size);
            if (categoryCode != 1234)
            {
                Assert.IsType<BadRequestObjectResult>(response.Result);
            }
            else
            {
                if (page == 2)
                {
                    Assert.IsType<NotFoundResult>(response.Result);
                }
                else if (categoryCode != 1234)
                {

                }
                else
                {
                    Assert.IsType<ActionResult<PageablePresenter<SubcategoryPresenter>>>(response);
                }
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
                Assert.IsType<ActionResult<SubcategoryPresenter>>(response);
            }
            else
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
        }

        [Fact]
        public async Task TestaCreate()
        {
            var obj = new SubcategoryCreateParameter()
            {
                Name = "Teste",
                Description = "descrição",
                CategoryCode = 1234
            };

            var response = await _controller.Post(obj);

            Assert.IsType<CreatedAtActionResult>(response.Result);
            Assert.IsType<ActionResult<SubcategoryPresenter>>(response);
        }

        [Theory]
        [InlineData(1234)]
        [InlineData(5678)]
        public async Task TestaUpdate(long code)
        {
            var subcategory = new SubcategoryParameter()
            {
                SubcategoryCode = code,
                CategoryCode = code,
                Description = "Teste atualizãção",
                IsActive = false,
                Name = "Atualizada"
            };

            var response = await _controller.Put(subcategory, code);
            if (code == 1234)
            {
                Assert.IsType<ActionResult<SubcategoryPresenter>>(response);
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
                Assert.IsType<ActionResult<SubcategoryPresenter>>(response);
            }
            else
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
        }
    }
}
