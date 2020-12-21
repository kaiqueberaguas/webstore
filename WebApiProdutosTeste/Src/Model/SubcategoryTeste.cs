using System;
using WebApiProdutos.Src.Models;
using Xunit;

namespace WebApiProdutosTeste.Src.Model
{
    public class SubcategoryTeste
    {
        [Fact]
        public void TestaPrepareToCreateRegister()
        {
            var subcategory = new Subcategory()
            {
                Id = 123,
                Code = 1234,
                Name = "Teste",
                Description = "Descrição teste",
                IsActive = true,
                LastModification = new DateTime(2001, 01, 01),
                RegisterDate = new DateTime(2001, 01, 01)   
            };
            subcategory.PrepareToCreateRegister();
            Assert.Equal(DateTime.Today, subcategory.LastModification.GetValueOrDefault().Date);
            Assert.Equal(DateTime.Today, subcategory.RegisterDate.GetValueOrDefault().Date);
            Assert.True(subcategory.Code.HasValue && subcategory.Code > 0 && subcategory.Code != 1234);
            Assert.False(subcategory.Id.HasValue);
        }
    }
}
