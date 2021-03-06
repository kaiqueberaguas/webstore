﻿using System;
using System.Threading.Tasks;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : Entity
    {
        Task<T> GetById(long id);
        Task<T> GetByCode(long code);
        Task<Pageable<T>> GetAll(int page, int size);
        Task<T> Update(T obj);
        Task<T> Insert(T obj);
        Task<T> Delete(long id);
    }
}
