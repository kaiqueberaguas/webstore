﻿using NUnit.Framework;
using WebApiProdutos.Src.Extensions;

namespace WebApiProdutosTeste.Src.Extensions
{
    public class StringExtensionTest
    {
        [SetUp]
        public void Initialize()
        {
        }

        [Test]
        public void TestToCaptalize()
        {
            string teste1 = "teste1";
            string teste2 = "plataforma";
            string teste3 = "Exibir";
            string teste4 = "OPERACIONAL";
            Assert.AreEqual(teste1.ToCaptalize(), "Teste1");
            Assert.AreEqual(teste2.ToCaptalize(), "Plataforma");
            Assert.AreEqual(teste3.ToCaptalize(), "Exibir");
            Assert.AreEqual(teste4.ToCaptalize(), "Operacional");
        }
    }
}
