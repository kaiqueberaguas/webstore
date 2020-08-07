using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace webApi.src.services
{
    public class SubcategoryService : ISubcategoryService
    {

        private readonly ISubcategoryRepository _subcategoryRepository;
        public SubcategoryService(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }
        public async Task<Subcategory> Get(long id)
        {
            return await _subcategoryRepository.GetById(id);
        }
        public async Task<List<Subcategory>> GetAll(int page, int size)
        {
            return await _subcategoryRepository.GetAll(page, size);
        }
        public async Task<Subcategory> Create(Subcategory obj)
        {
            return await _subcategoryRepository.Insert(obj);
        }
        public async Task<Subcategory> Update(Subcategory obj)
        {
            return await _subcategoryRepository.Update(obj);
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
