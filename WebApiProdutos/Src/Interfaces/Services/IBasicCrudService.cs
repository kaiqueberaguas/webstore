using System.Threading.Tasks;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Interfaces.Services
{
    public interface IBasicCrudService<T> where T : Entity
    {
        Task<Pageable<T>> GetAll(int page, int size);
        Task<T> Get(long Code);
        Task<T> Update(long code, T obj);
        Task<T> PartialUpdate(long code, T obj);
        Task<T> Create(T obj);
        Task<T> Delete(long code);

    }
}
