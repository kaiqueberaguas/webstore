﻿using Microsoft.Extensions.DependencyInjection;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.repositories;
using webApi.src.Sercutity;
using webApi.src.services;
using WebApi.src.Sercutity;

namespace webApi.src.extensions
{
    public static class DependenciesInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
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
            #region default
            services.AddScoped<IAdmintrationService, AdmintrationService>();
            services.AddScoped<AccessManager>();
            services.AddScoped<RegisterUserManager>();
            #endregion
        }
    }
}
