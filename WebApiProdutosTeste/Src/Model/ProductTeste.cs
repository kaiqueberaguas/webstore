using System;
using WebApiProdutos.Src.Models;
using Xunit;

namespace WebApiProdutosTeste.Src.Model
{
    public class ProductTeste
    {

        [Fact]
        public void TestaPrepareToCreateRegister()
        {
            var product = new Product()
            {
                Id = 123,
                Code = 1234,
                Amount = 20.9M,
                AvailableQuantity = 3,
                Name = "Teste",
                Description = "Descrição teste",
                Information = "Informação teste",
                IsActive = true,
                LastModification = new DateTime(2001, 01, 01),
                LimitDate = new DateTime(2001, 01, 01),
                RegisterDate = new DateTime(2001, 01, 01),
                PurchaseDate = new DateTime(2001, 01, 01),   
            };
            product.PrepareToCreateRegister();
            Assert.Equal(DateTime.Today, product.LastModification.GetValueOrDefault().Date);
            Assert.Equal(DateTime.Today, product.RegisterDate.GetValueOrDefault().Date);
            Assert.True(product.Code.HasValue && product.Code > 0 && product.Code != 1234);
            Assert.False(product.Id.HasValue);
        }

    }
}
