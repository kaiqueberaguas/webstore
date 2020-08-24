using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;

namespace WebApi.Src.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
