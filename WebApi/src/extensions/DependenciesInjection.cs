using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.repositories;
using webApi.src.services;

namespace webApi.src.extensions
{
    public class DependenciesInjection
    {
        public static void RegistryRepository(IServiceCollection services)
        {
            #region repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            #endregion
            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPriceService, PriceService>();
            #endregion
        }
    }
}
