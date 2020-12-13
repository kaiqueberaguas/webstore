using System.Threading.Tasks;
using webApi.src.models;
using WebApi.Src.Models;

namespace webApi.src.interfaces.services
{
    public interface IBasicCrudService<T> where T : Entity
    {
        Task<Pageable<T>> GetAll(int page, int size);
        Task<T> Get(long Code);
        Task<T> Update(T obj);
        Task<T> Create(T obj);
        Task<T> Delete(long code);

    }
}
