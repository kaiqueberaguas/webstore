using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiProdutos.Src.Interfaces.Services;
using WebApiProdutos.Src.Models;

namespace WebApiProdutosTeste.Src.Mock
{
    public class ProductServiceMock : IProductService, IDisposable
    {
        public ProductServiceMock()
        {
        }

        public Task<Product> Create(Product obj)
        {
            obj.PrepareToCreateRegister();
            return Task.Run(() => { return obj; });
        }

        public Task<Product> Get(long code) => (code == 1234) ? Task.Run(() =>
        {
            return new Product() { Name = "Produto teste", Description = "Descrição de teste", Code = code };
        }) : Task.FromResult<Product>(null);

        public Task<Pageable<Product>> GetBySubcategory(long subcategoryCode, int page, int size) => (subcategoryCode == 1234) ? Task.Run(() =>
        {
            var products = new List<Product>();
            if (page != 2)
            {
                for (int i = 0; i < size; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Teste {i}",
                        Description = $"Descrição do Teste {i}",
                        Code = i
                    };
                    products.Add(product);
                }
            }
            return Task.Run(() => new Pageable<Product>(products, products.Count, page, size));
        }) : throw new Exception("Subcategoria não encontrada");

        public Task<Pageable<Product>> GetAll(int page, int size)
        {
            var products = new List<Product>();
            if (page != 2)
            {
                for (int i = 0; i < size; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Teste {i}",
                        Description = $"Descrição do Teste {i}",
                        Code = i
                    };
                    products.Add(product);
                }
            }
            return Task.Run(() => new Pageable<Product>(products, products.Count, page, size));
        }

        public Task<Product> PartialUpdate(long code, Product obj)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(long code, Product obj) => (code == 1234) ? Task.Run(() =>
        {
            return new Product() { Name = "Produto teste", Description = "Descrição de teste", Code = code };
        }) : Task.FromResult<Product>(null);


        public Task<Product> Delete(long code) => (code == 1234) ? Task.Run(() =>
        {
            return new Product() { Name = "Produto teste", Description = "Descrição de teste", Code = code };
        }) : Task.FromResult<Product>(null);


        public void Dispose()
        {
        }

    }
}
