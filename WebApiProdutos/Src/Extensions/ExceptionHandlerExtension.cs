using Microsoft.AspNetCore.Builder;

namespace WebApiProdutos.Src.Extensions
{
    public static class ExceptionHandlerExtension
    {

        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    //_logger.LogError(context.Features.Get<IExceptionHandlerFeature>().Error.Message);
                    //_logger.LogError(context.Features.Get<IExceptionHandlerFeature>().Error.StackTrace);
                    context.Response.StatusCode = 500;
                });
            });
        }
    }
}
