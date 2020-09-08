using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace WebApi.Src.Services
{
    public class SubcategoryService : ISubcategoryService
    {

        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Subcategory> Get(long code)
        {
            return await _subcategoryRepository.GetByCode(code);
        }
        public async Task<List<Subcategory>> GetAll(int page, int size)
        {
            return await _subcategoryRepository.GetAll(page, size);
        }
        public async Task<Subcategory> Create(Subcategory obj)
        {
            var category = await _categoryRepository.GetByCode(obj.Category.Code.Value);
            if (category is null)
            {
                return null;
            }
            obj.Category = category;
            return await _subcategoryRepository.Insert(obj);
        }
        public async Task<Subcategory> Update(Subcategory obj)
        {
            var result = await _subcategoryRepository.GetById(obj.Id.Value);
            if (result is null)
            {
                return null;
            }
            result.Update(obj);
            return await _subcategoryRepository.Update(result);
        }
        public async Task<Subcategory> Delete(long id)
        {
            return await _subcategoryRepository.Delete(id);
        }
        public async Task<Subcategory> Delete(Subcategory obj)
        {
            return await _subcategoryRepository.Delete(obj);
        }
    }
}
