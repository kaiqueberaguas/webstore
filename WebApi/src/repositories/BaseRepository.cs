﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;

namespace WebApi.Src.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {

        private readonly StoreContext _storeContext;
        public BaseRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void Dispose()
        {
            _storeContext.Dispose();
        }

        public virtual async Task<T> GetById(long Id)
        {
            return await _storeContext.Set<T>().FindAsync(Id);
        }
        public virtual async Task<List<T>> GetAll(int page, int pageSize)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 1;
            return await _storeContext.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public virtual async Task<T> Insert(T obj)
        {
            obj.PrepareCreateRecord();
            _storeContext.Set<T>().Add(obj);
            await _storeContext.SaveChangesAsync();
            return obj;
        }
        public virtual async Task<T> Update(T obj)
        {
            obj.UpdateRecorde();
            _storeContext.Entry(obj).State = EntityState.Modified;
            await _storeContext.SaveChangesAsync();
            return obj;
        }
        public virtual async Task<T> Delete(long id)
        {
            var obj = _storeContext.Set<T>().Find(id);
            if (obj != null)
            {
                _storeContext.Set<T>().Remove(obj);
                await _storeContext.SaveChangesAsync();
            }
            return obj;
        }
        public virtual async Task<T> Delete(T obj)
        {
            var result = _storeContext.Set<T>().Find(obj.Id);
            if (result != null)
            {
                _storeContext.Set<T>().Remove(obj);
                await _storeContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<T> GetByCode(long code)
        {
            return await _storeContext.Set<T>().Where(e => e.Code == code).FirstOrDefaultAsync();
        }
    }
}
