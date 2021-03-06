﻿using Microsoft.Extensions.Logging;
using WebApiProdutos.Src.Dbcontext;
using WebApiProdutos.Src.Interfaces.Repositories;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext storeContext, ILogger<CategoryRepository> logger) : base(storeContext, logger)
        {
        }
    }
}
