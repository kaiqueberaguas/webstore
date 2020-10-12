using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using webApi.src.extensions;
using WebApi.Src.Extensions;
using WebApi.Src.Infra.Log;

namespace WebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseConfigure(Configuration);
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddSwaggerConfigure();
            services.AddDependencyInjection();
            services.AddJwtSecurity(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(name: "https://localhost*",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();//ajustar restrição de cors e restrição de metodos
                    });
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseGlobalExceptionHandler();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("https://localhost*");
            app.UseAuthorization();
            #region swagger
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "web Store v1");
            });

            var options = new RewriteOptions();
            options.AddRedirect("^$", "swagger");
            app.UseRewriter(options);
            #endregion
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
