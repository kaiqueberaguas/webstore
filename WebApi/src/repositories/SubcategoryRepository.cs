using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;

namespace WebApi.Src.Repositories
{
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
