using System.Threading.Tasks;
using webApi.src.models;
using WebApi.Src.Models;

namespace webApi.src.interfaces.services
{
    public interface IProductService : IBasicCrudService<Product>
    {
        Task<Pageable<Product>> GetAll(int page, int size, long subcategoryCode);
    }
}
