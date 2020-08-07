using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using webApi.src.dbcontext;
using webApi.src.extensions;

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
            #region database_configuration
            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("SqlServerConnectionString"));
            builder.Password = Configuration["SECRETY_DATABASE"];   
            #endregion
            services.AddEntityFrameworkSqlServer().AddDbContext<StoreContext>(options => options.UseSqlServer(builder.ConnectionString));
            #region identity
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();//todo
            #endregion
            services.AddControllers();
            services.AddDependencyInjection();
            #region swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = ".web Store Api",
                    Description = "Api de acesso aos produtos e categorias da loja, projeto de estudo do .Net core",
                    Contact = new OpenApiContact()
                    {
                        Name = "Kaique Beraguas",
                        Email = "kaiqueberaguas@gmail.com",
                        Url = new Uri(@"https://www.linkedin.com/in/kaique-beraguas/")
                    },
                    Version = "v1"
                });
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
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
