using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.dbcontext;
using webApi.src.interfaces.repositories;
using webApi.src.models;

namespace webApi.src.repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
