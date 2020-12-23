using Microsoft.AspNetCore.Builder;

namespace WebApiProdutos.Src.Extensions
{
    public static class ExceptionHandlerExtension
    {
        
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context => context.Response.StatusCode = 500);
            });
        }
    }
}
