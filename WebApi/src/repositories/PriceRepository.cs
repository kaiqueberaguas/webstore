using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;

namespace WebApi.Src.Repositories
{
    public class PriceRepository : BaseRepository<Price>, IPriceRepository
    {
        public PriceRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
