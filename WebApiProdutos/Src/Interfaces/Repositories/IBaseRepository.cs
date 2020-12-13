using System;
using System.Threading.Tasks;
using webApi.src.models;
using WebApi.Src.Models;

namespace webApi.src.interfaces.repositories
{
    public interface IBaseRepository<T> : IDisposable where T : Entity
    {
        Task<T> GetById(long Id);
        Task<T> GetByCode(long Code);
        Task<Pageable<T>> GetAll(int page, int size);
        Task<T> Update(T obj);
        Task<T> Insert(T obj);
        Task<T> Delete(long id);
    }
}
