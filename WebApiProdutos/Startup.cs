using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using WebApiProdutos.Src.Extensions;

namespace WebApiProdutos
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(configuration.GetSection("logger.path").Value)
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseConfigure(Configuration);
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddSwaggerConfigure();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "PoliticaCorsLocalHost",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                      .AllowAnyMethod().AllowAnyHeader();
                                  });
            });
            services.AddDependencyInjection();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            app.UseHttpsRedirection();
            app.UseGlobalExceptionHandler();
            app.UseCors("PoliticaCorsLocalHost");
            app.UseRouting();
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
