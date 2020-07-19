using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task Create(Product obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
