using System.Threading.Tasks;
using webApi.src.models;
using WebApi.Src.Models;

namespace webApi.src.interfaces.services
{
    public interface ISubcategoryService : IBasicCrudService<Subcategory>
    {
        Task<Pageable<Subcategory>> GetAllByCategory(long categoryCode, int page, int size);
    }
}
