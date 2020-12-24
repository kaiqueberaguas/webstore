using System.Threading.Tasks;
using WebPlataformBlazor.Src.Code.Models;

namespace WebPlataformBlazor.Src.Code.Interfaces
{
    public interface IBasicCrudService<T> where T : BaseModel
    {
        Task<Pageable<T>> GetAll(int page, int size);
        Task<T> Get(long code);
        Task<T> Update(long code, T obj);
        Task<T> Create(T obj);
        Task<T> Delete(long code);

    }
}
