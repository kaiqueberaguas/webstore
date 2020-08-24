using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;

namespace WebApi.Src.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
