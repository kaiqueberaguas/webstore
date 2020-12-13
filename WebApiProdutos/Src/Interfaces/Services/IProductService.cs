using System.Threading.Tasks;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Interfaces.Services
{
    public interface IProductService : IBasicCrudService<Product>
    {
        Task<Pageable<Product>> GetAll(int page, int size, long subcategoryCode);
    }
}
