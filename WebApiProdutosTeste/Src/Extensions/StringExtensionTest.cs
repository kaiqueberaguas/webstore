using WebApiProdutos.Src.Extensions;
using Xunit;

namespace WebApiProdutosTeste.Src.Extensions
{
    public class StringExtensionTest
    {

        [Theory]
        [InlineData("Teste", "Teste")]
        [InlineData("TESTE", "Teste")]
        [InlineData("tESTE", "Teste")]
        [InlineData("TES4te", "Tes4te")]
        [InlineData("45Est", "45est")]
        public void ToCaptalizeTest(string entrada, string esperado)
        {
            Assert.Equal(esperado, entrada.ToCaptalize());
        }
    }
}
