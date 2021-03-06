﻿using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApiProdutos.Src.Interfaces.Repositories;
using WebApiProdutos.Src.Interfaces.Services;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Services
{
    public class SubcategoryService : ISubcategoryService
    {

        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<SubcategoryService> _logger;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository, ILogger<SubcategoryService> logger)
        {
            _subcategoryRepository = subcategoryRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Subcategory> Get(long code)
        {
            return await _subcategoryRepository.GetByCode(code);
        }
        public async Task<Pageable<Subcategory>> GetAll(int page, int size)
        {
            return await _subcategoryRepository.GetAll(page, size);
        }

        public async Task<Pageable<Subcategory>> GetAllByCategory(long categoryCode, int page, int size)
        {
            return await _subcategoryRepository.GetAllByCategory(categoryCode, page, size);
        }

        public async Task<Subcategory> Create(Subcategory obj)
        {
            var category = await _categoryRepository.GetByCode(obj.Category.Code.GetValueOrDefault());
            if (category is null)
            {
                throw new Exception("Categoria não encontrada");
            }
            obj.Category = category;
            return await _subcategoryRepository.Insert(obj);
        }
        public async Task<Subcategory> Update(long code, Subcategory obj)
        {
            var result = await _subcategoryRepository.GetByCode(obj.Code.GetValueOrDefault());
            if (result is null)
            {
                return result;
            }
            var category = await _categoryRepository.GetByCode(obj.Category.Code.GetValueOrDefault());
            obj.Category = category;
            result.Update(obj);
            return await _subcategoryRepository.Update(result);
        }

        public Task<Subcategory> PartialUpdate(long code, Subcategory obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Subcategory> Delete(long code)
        {
            var obj = await _subcategoryRepository.GetByCode(code);
            if (obj != null)
                return await _subcategoryRepository.Delete(obj.Id.GetValueOrDefault());
            return obj;
        }
    }
}
