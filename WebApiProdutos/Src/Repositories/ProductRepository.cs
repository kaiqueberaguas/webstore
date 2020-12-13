using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApiProdutos.Src.Dbcontext;
using WebApiProdutos.Src.Interfaces.Repositories;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        public async Task<Pageable<Product>> GetAll(int page, int size, long subcategoryCode)
        {
            if (page <= 0) page = 1;
            if (size <= 0) size = 1;
            var list = await _storeContext.Products
                .Where(p => p.Subcategory.Code == subcategoryCode)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            var count = await _storeContext.Products
                .Where(p => p.Subcategory.Code == subcategoryCode)
                .CountAsync();

            return new Pageable<Product>(list, count, page, size);

        }
    }
}
