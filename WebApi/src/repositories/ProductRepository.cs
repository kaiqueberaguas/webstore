using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;
using WebApi.Src.Models;

namespace WebApi.Src.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        public async Task<Pageable<Product>> GetAll(int page, int pageSize, long subcategoryCode)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 1;
            var list = await _storeContext.Products
                .Where(p => p.Subcategory.Code == subcategoryCode)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var count = await _storeContext.Products
                .Where(p => p.Subcategory.Code == subcategoryCode)
                .CountAsync();

            return new Pageable<Product>(list, count, page, pageSize);

        }
    }
}
