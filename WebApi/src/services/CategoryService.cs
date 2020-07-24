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
        public async Task<Category> Get(long id)
        {
            return await _categoryRepository.GetById(id);
        }
        public async Task<List<Category>> GetAll(int page, int size)
        {
            return await _categoryRepository.GetAll(page, size);
        }
        public async Task<Category> Create(Category obj)
        {
            return await _categoryRepository.Insert(obj);
        }
        public async Task Update(Category obj)
        {
            await _categoryRepository.Update(obj);
        }
        public async Task<Category> Delete(long id)
        {
            return await _categoryRepository.Delete(id);
        }
        public async Task Delete(Category obj)
        {
            await _categoryRepository.Delete(obj);
        }
    }
}
