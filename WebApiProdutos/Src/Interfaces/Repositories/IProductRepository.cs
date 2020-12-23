using System.Threading.Tasks;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Pageable<Product>> GetAll(long subcategoryCode, int page, int size);
    }
}
