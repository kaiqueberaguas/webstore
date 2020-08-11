﻿using System;
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

        public async Task<Price> Get(long id)
        {
            return await _priceRepository.GetById(id);
        }
        public async Task<List<Price>> GetAll(int page, int size)
        {
            return await _priceRepository.GetAll(page,size);
        }
        public async Task<Price> Update(Price obj)
        {
            var result = await _priceRepository.GetById(obj.Id.Value);
            if (result is null)
            {
                return null;
            }
            result.Update(obj);
            return await _priceRepository.Update(result);
        }
        public async Task<Price> Create(Price obj)
        {
            return await _priceRepository.Insert(obj);
        }
        public async Task<Price> Delete(long id)
        {
            return await _priceRepository.Delete(id);
        }
        public async Task<Price> Delete(Price obj)
        {
            return await _priceRepository.Delete(obj);
        }
    }
}
