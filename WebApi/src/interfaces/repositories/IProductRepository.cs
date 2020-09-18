using System.Threading.Tasks;
using webApi.src.models;
using WebApi.Src.Models;

namespace webApi.src.interfaces.repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Pageable<Product>> GetAll(int page, int pageSize,long subcategoryCode);
    }
}
