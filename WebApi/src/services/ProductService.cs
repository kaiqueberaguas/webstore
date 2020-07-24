using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace webApi.src.services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Get(long id)
        {
            return await _productRepository.GetById(id);
        }
        public async Task<List<Product>> GetAll(int page, int size)
        {
            return await _productRepository.GetAll(page, size);
        }
        public async Task<Product> Create(Product obj)
        {
            return await _productRepository.Insert(obj);
        }
        public async Task Update(Product obj)
        {
            await _productRepository.Update(obj);
        }
        public async Task<Product> Delete(long id)
        {
            return await _productRepository.Delete(id);
        }
        public async Task Delete(Product obj)
        {
            await _productRepository.Delete(obj);
        }
    }
}
