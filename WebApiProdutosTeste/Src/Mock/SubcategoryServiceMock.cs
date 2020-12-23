using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiProdutos.Src.Interfaces.Services;
using WebApiProdutos.Src.Models;

namespace WebApiProdutosTeste.Src.Mock
{
    public class SubcategoryServiceMock : ISubcategoryService, IDisposable
    {
        public SubcategoryServiceMock()
        {
        }

        public Task<Subcategory> Create(Subcategory obj)
        {
            obj.PrepareToCreateRegister();
            return Task.Run(() => { return obj; });
        }

        public Task<Subcategory> Get(long code) => (code == 1234) ? Task.Run(() =>
        {
            return new Subcategory() { Name = "Subcategoria teste", Description = "Descrição de teste", Code = 1234 };
        }) : Task.FromResult<Subcategory>(null);

        public Task<Pageable<Subcategory>> GetAll(int page, int size)
        {
            if (page == 2) return Task.Run(() => new Pageable<Subcategory>(new List<Subcategory>(), 0, page, size));
            var subcategories = new List<Subcategory>();
            for (int i = 0; i < size; i++)
            {
                var subcategory = new Subcategory()
                {
                    Name = $"Teste {i}",
                    Description = $"Descrição do Teste {i}",
                    Code = i
                };
                subcategories.Add(subcategory);
            }
            return Task.Run(() => new Pageable<Subcategory>(subcategories, subcategories.Count, page, size));
        }


        public Task<Pageable<Subcategory>> GetAllByCategory(long categoryCode, int page, int size) => (categoryCode == 1234) ? Task.Run(() =>
        {
            var subcategories = new List<Subcategory>();
            if(page != 2)
            {
                for (int i = 0; i < size; i++)
                {
                    var subcategory = new Subcategory()
                    {
                        Name = $"Teste {i}",
                        Description = $"Descrição do Teste {i}",
                        Code = i
                    };
                    subcategories.Add(subcategory);
                }
            }
            return Task.Run(() => new Pageable<Subcategory>(subcategories, subcategories.Count, page, size));
        }) : throw new Exception("Categoria não encontrada");

        public Task<Subcategory> PartialUpdate(long code, Subcategory obj)
        {
            throw new NotImplementedException();
        }

        public Task<Subcategory> Update(long code, Subcategory obj) => (code == 1234) ? Task.Run(() =>
        {
            return new Subcategory() { Name = "Subcategoria teste", Description = "Descrição de teste", Code = 1234 };
        }) : Task.FromResult<Subcategory>(null);

        public Task<Subcategory> Delete(long code) => (code == 1234) ? Task.Run(() =>
            {
                return new Subcategory() { Name = "Subcategoria teste", Description = "Descrição de teste", Code = 1234 };
            }) : Task.FromResult<Subcategory>(null);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
