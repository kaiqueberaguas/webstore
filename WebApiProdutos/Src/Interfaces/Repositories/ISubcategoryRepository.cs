using System.Threading.Tasks;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Interfaces.Repositories
{
    public interface ISubcategoryRepository : IBaseRepository<Subcategory>
    {
        Task<Pageable<Subcategory>> GetAllByCategory(long categoryCode, int page, int size);
    }
}
