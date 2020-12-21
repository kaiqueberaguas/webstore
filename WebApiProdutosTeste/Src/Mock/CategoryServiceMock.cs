using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiProdutos.Src.Interfaces.Services;
using WebApiProdutos.Src.Models;

namespace WebApiProdutosTeste.Src.Mock
{
    public class CategoryServiceMock : ICategoryService, IDisposable
    {
        public CategoryServiceMock()
        {
        }

        public Task<Category> Create(Category obj)
        {
            obj.PrepareToCreateRegister();
            return Task.Run(() => { return obj; });
        }

        public Task<Category> Get(long Code) => (Code != 1234) ? new Task<Category>(() =>
        {
            return new Category() { Name = $"Teste", Description = $"Descrição do Teste", Code = 1234 };
        }) : null;

        public Task<Pageable<Category>> GetAll(int page, int size)
        {
            if (page == 2) Task.Run(() => new Pageable<Category>(new List<Category>(), 0, page, size));
            var categories = new List<Category>();
            for (int i = 0; i < size; i++)
            {
                var contato = new Category()
                {
                    Name = $"Teste {i}",
                    Description = $"Descrição do Teste {i}",
                    Code = i
                };
                categories.Add(contato);
            }
            return Task.Run(() => new Pageable<Category>(categories, categories.Count, page, size));
        }

        public Task<Category> PartialUpdate(long code, Category obj)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(long code, Category obj)
        {
            throw new NotImplementedException();
        }
        public Task<Category> Delete(long code)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
