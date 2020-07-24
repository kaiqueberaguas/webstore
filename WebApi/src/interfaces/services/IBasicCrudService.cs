using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.interfaces.services
{
    public interface IBasicCrudService<T> where T : class
    {
        Task<List<T>> GetAll(int page, int size);
        Task<T> Get(long id);
        Task Update(T obj);
        Task<T> Create(T obj);
        Task<T> Delete(long id);
        Task Delete(T obj);

    }
}
