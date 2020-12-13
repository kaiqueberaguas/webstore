using System.Threading.Tasks;
using webApi.src.models;
using WebApi.Src.Models;

namespace webApi.src.interfaces.repositories
{
    public interface ISubcategoryRepository : IBaseRepository<Subcategory>
    {
        Task<Pageable<Subcategory>> GetAllByCategory(long categoryCode, int page, int size);
    }
}
