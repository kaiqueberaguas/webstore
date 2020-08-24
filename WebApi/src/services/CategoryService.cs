using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace WebApi.Src.Services
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
        public async Task<Category> Update(Category obj)
        {
            var result = await _categoryRepository.GetById(obj.Id.Value);
            if (result is null)
            {
                return null;
            }
            result.Update(obj);
            return await _categoryRepository.Update(result);
        }
        public async Task<Category> Delete(long id)
        {
            return await _categoryRepository.Delete(id);
        }
        public async Task<Category> Delete(Category obj)
        {
            return await _categoryRepository.Delete(obj);
        }
    }
}
