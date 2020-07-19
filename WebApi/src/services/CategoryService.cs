using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace webApi.src.services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task Create(Category obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
