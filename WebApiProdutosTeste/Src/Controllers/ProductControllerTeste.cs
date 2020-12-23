using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiProdutos.Src.Controllers;
using WebApiProdutos.Src.Controllers.Parameters;
using WebApiProdutos.Src.Presenters;
using WebApiProdutosTeste.Src.Mock;
using Xunit;

namespace WebApiProdutosTeste.Src.Controllers
{
    public class ProductControllerTeste
    {
        private readonly ProductController _controller;
        private readonly ProductServiceMock _service;
        private readonly ILogger<ProductController> _logger = LoggerFactory.Create(l => l.AddDebug()).CreateLogger<ProductController>();

        public ProductControllerTeste()
        {
            _service = new ProductServiceMock();
            _controller = new ProductController(_service, _logger);
        }

        [Theory]
        [InlineData(1234, 1, 15)]
        [InlineData(1234, 2, 15)]
        [InlineData(5678, 2, 15)]
        public async Task TestaGetPaginado(long subcategoryCode, int page, int size)
        {
            var response = await _controller.Get(subcategoryCode, page, size);
            if (subcategoryCode != 1234)
            {
                Assert.IsType<BadRequestObjectResult>(response.Result);
            }
            else
            {
                if (page == 2)
                {
                    Assert.IsType<NotFoundResult>(response.Result);
                }
                else
                {
                    Assert.IsType<ActionResult<PageablePresenter<ProductPresenter>>>(response);
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
                Assert.IsType<ActionResult<ProductPresenter>>(response);
            }
            else
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
        }

        [Fact]
        public async Task TestaCreate()
        {
            var obj = new ProductCreateParameter()
            {
                Name = "Teste",
                Description = "descrição",
                Information = "Informação de teste",
                Amount = 20.0M,
                PurchaseDate = DateTime.Today,
                SubcategoryCode = 1234
            };

            var response = await _controller.Post(obj);

            Assert.IsType<CreatedAtActionResult>(response.Result);
            Assert.IsType<ActionResult<ProductPresenter>>(response);
        }

        [Theory]
        [InlineData(1234)]
        [InlineData(5678)]
        public async Task TestaUpdate(long code)
        {
            var product = new ProductParameter()
            {
                ProductCode = code,
                SubcategoryCode = code,
                Description = "Teste atualizãção",
                IsActive = false,
                Name = "Atualizada"
            };

            var response = await _controller.Put(product, code);
            if (code == 1234)
            {
                Assert.IsType<ActionResult<ProductPresenter>>(response);
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
                Assert.IsType<ActionResult<ProductPresenter>>(response);
            }
            else
            {
                Assert.IsType<NotFoundResult>(response.Result);
            }
        }
    }
}
