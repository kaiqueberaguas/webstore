using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;
using WebApi.Src.Models;

namespace WebApi.Src.Repositories
{
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        public async Task<Pageable<Subcategory>> GetAllByCategory(long categoryCode, int page, int size)
        {
            if (page <= 0) page = 1;
            if (size <= 0) size = 1;
            var list = await _storeContext.SubCategories
                .Where(s => s.Category.Code == categoryCode)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            var count = await _storeContext.SubCategories
                 .Where(s => s.Category.Code == categoryCode)
                .CountAsync();

            return new Pageable<Subcategory>(list, count, page, size);
        }
    }
}
