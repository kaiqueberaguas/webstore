using System;
using WebApiProdutos.Src.Models;
using Xunit;

namespace WebApiProdutosTeste.Src.Model
{
    public class CategoryTeste
    {

        [Fact]
        public void TestaPrepareToCreateRegister()
        {
            var category = new Category()
            {
                Id = 123,
                Code = 1234,
                Description = "Teste",
                IsActive = false,
                LastModification = new DateTime(2001,01,01),
                Name = "Teste nome",
                RegisterDate = new DateTime(2001, 01, 01)
            };
            category.PrepareToCreateRegister();
            Assert.Equal(DateTime.Today, category.LastModification.GetValueOrDefault().Date);
            Assert.Equal(DateTime.Today, category.RegisterDate.GetValueOrDefault().Date);
            Assert.True(category.Code.HasValue && category.Code > 0 && category.Code != 1234);
            Assert.False(category.Id.HasValue);
        }

    }
}
