﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.interfaces.repositories
{
    public interface IBaseRepository<T> : IDisposable where T : Entity
    {
        public Task<T> GetById(long Id);
        public Task<List<T>> GetAll(int page, int pageSize);
        public Task Update(T obj);
        public Task<T> Insert(T obj);
        public Task<T> Delete(long id);
        public Task Delete(T obj);
    }
}
