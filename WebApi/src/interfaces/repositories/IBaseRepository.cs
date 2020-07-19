using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.interfaces.repositories
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        public Task<T> GetById(long? Id);
        public Task<List<T>> GetAll(int page, int pageSize);
        public Task Update(T obj);
        public Task Insert(T obj);
        public Task Delete(T obj);
    }
}
