﻿using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace WebApi.Src.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Get(long code)
        {
            return await _productRepository.GetByCode(code);
        }
        public async Task<List<Product>> GetAll(int page, int size)
        {
            return await _productRepository.GetAll(page, size);
        }
        public async Task<Product> Create(Product obj)
        {
            return await _productRepository.Insert(obj);
        }
        public async Task<Product> Update(Product obj)
        {
            var result = await _productRepository.GetById(obj.Id.Value);
            if (result is null)
            {
                return null;
            }
            result.Update(obj);
            return await _productRepository.Update(result);
        }
        public async Task<Product> Delete(long id)
        {
            return await _productRepository.Delete(id);
        }
        public async Task<Product> Delete(Product obj)
        {
            return await _productRepository.Delete(obj);
        }
    }
}
