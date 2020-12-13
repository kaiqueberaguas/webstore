using Blazored.Modal;
using Microsoft.Extensions.DependencyInjection;
using WebPlataformBlazor.Src.Code.Services;

namespace WebPlataformBlazor.Src.Code.Extensions
{
    public static class DependenciesInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddBlazoredModal();
            #region Services
            services.AddScoped<CategoryPageService>();
            services.AddScoped<SubcategoryPageService>();
            services.AddScoped<ProductsPageService>();
            #endregion

        }
    }
}
