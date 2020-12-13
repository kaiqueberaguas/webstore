using Microsoft.Extensions.DependencyInjection;
using WebApiProdutos.Src.Interfaces.Repositories;
using WebApiProdutos.Src.Interfaces.Services;
using WebApiProdutos.Src.Repositories;
using WebApiProdutos.Src.Services;

namespace WebApiProdutos.Src.Extensions
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
            //#region default
            //services.AddScoped<IAdmintrationService, AdmintrationService>();
            //services.AddScoped<AccessManager>();
            //services.AddScoped<RegisterUserManager>();
            //#endregion
        }
    }
}
