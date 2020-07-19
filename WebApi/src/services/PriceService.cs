using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.models;

namespace webApi.src.services
{
    public class PriceService : IPriceService
    {

        private readonly IPriceRepository _priceRepository;
        public PriceService(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public Task Create(Price obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Price> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Price>> GetAll(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task Update(Price obj)
        {
            throw new NotImplementedException();
        }
    }
}
