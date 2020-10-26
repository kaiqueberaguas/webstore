using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;
using WebApi.Src.Models;

namespace WebApi.Src.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly ISubcategoryRepository _subcategoryrepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ISubcategoryRepository subcategoryrepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _subcategoryrepository = subcategoryrepository;
            _logger = logger;
        }

        public async Task<Product> Get(long code)
        {
            return await _productRepository.GetByCode(code);
        }
        public async Task<Pageable<Product>> GetAll(int page, int size)
        {
            return await _productRepository.GetAll(page, size);
        }
        public async Task<Pageable<Product>> GetAll(int page, int size,long subcategoryCode)
        {
            return await _productRepository.GetAll(page, size, subcategoryCode);
        }

        public async Task<Product> Create(Product obj)
        {
            var subcategory = await _subcategoryrepository.GetByCode(obj.Subcategory.Code.GetValueOrDefault());
            if(subcategory is null)
            {
                _logger.LogError($"Subcategoria codigo:{obj.Subcategory.Code.GetValueOrDefault()} não encontrada");
                return null;
            }
            obj.Subcategory = null;
            obj.SubcategoryId = subcategory.Id;
            return await _productRepository.Insert(obj);
        }
        
        public async Task<Product> Update(Product obj)
        {
            var result = await _productRepository.GetByCode(obj.Code.GetValueOrDefault());
            if (result is null)
            {
                return null;
            }
            result.Update(obj);
            return await _productRepository.Update(result);
        }
        
        public async Task<Product> Delete(long code)
        {
            var obj = await _productRepository.GetByCode(code);
            if (obj != null)
                return await _productRepository.Delete(obj.Id.GetValueOrDefault());
            return null;
        }
    }
}
