using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;
using WebApi.Src.Models;

namespace WebApi.Src.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Get(long code)
        {
            return await _categoryRepository.GetByCode(code);
        }
        public async Task<Pageable<Category>> GetAll(int page, int size)
        {
            return await _categoryRepository.GetAll(page, size);
        }
        public async Task<Category> Create(Category obj)
        {
            return await _categoryRepository.Insert(obj);
        }
        public async Task<Category> Update(Category obj)
        {
            var result = await _categoryRepository.GetByCode(obj.Code.GetValueOrDefault());
            if (result is null)
            {
                return null;
            }
            result.Update(obj);
            return await _categoryRepository.Update(result);
        }
        public async Task<Category> Delete(long code)
        {
            var obj = await _categoryRepository.GetByCode(code);
            if (obj != null)
                return await _categoryRepository.Delete(obj.Id.GetValueOrDefault());
            return null;
        }
    }
}
