using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiProdutos.Src.Dbcontext;
using WebApiProdutos.Src.Interfaces.Repositories;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Repositories
{
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(StoreContext storeContext, ILogger<SubcategoryRepository> logger) : base(storeContext, logger)
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
