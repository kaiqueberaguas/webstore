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

        public Task Create(Subcategory obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Subcategory> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subcategory>> GetAll(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task Update(Subcategory obj)
        {
            throw new NotImplementedException();
        }
    }
}
