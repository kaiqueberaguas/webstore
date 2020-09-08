using Microsoft.Extensions.DependencyInjection;
using webApi.src.interfaces.repositories;
using webApi.src.interfaces.services;
using webApi.src.Sercutity;
using WebApi.src.Sercutity;
using WebApi.Src.Repositories;
using WebApi.Src.Services;

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
            #endregion
            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
            services.AddScoped<IProductService, ProductService>();
            #endregion
            #region default
            services.AddScoped<IAdmintrationService, AdmintrationService>();
            services.AddScoped<AccessManager>();
            services.AddScoped<RegisterUserManager>();
            #endregion
        }
    }
}
