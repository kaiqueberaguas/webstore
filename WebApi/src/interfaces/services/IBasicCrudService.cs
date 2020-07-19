using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.interfaces.services
{
    public interface IBasicCrudService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int page, int size);
        Task<T> Get(long id);
        Task Update(T obj);
        Task Create(T obj);
        Task Delete(long id);

    }
}
