using System.Threading.Tasks;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Interfaces.Services
{
    public interface ISubcategoryService : IBasicCrudService<Subcategory>
    {
        Task<Pageable<Subcategory>> GetAllByCategory(long categoryCode, int page, int size);
    }
}
