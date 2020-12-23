using System.Threading.Tasks;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Interfaces.Services
{
    public interface IProductService : IBasicCrudService<Product>
    {
        Task<Pageable<Product>> GetBySubcategory(long subcategoryCode, int page, int size);
    }
}
