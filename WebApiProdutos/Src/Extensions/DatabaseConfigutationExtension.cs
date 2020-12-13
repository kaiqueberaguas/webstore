using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApiProdutos.Src.Dbcontext;

namespace WebApiProdutos.Src.Extensions
{
    public static class DatabaseConfigutationExtension
    {
        public static readonly ILoggerFactory logger = LoggerFactory.Create(builder => builder.AddDebug().AddConsole());
        public static IServiceCollection AddDataBaseConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            #region database_configuration
            var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString("SqlServerConnectionString"));
            builder.Password = configuration["SECRETY_DATABASE"];
            #endregion

            services.AddDbContext<StoreContext>(options => options
                //.UseLoggerFactory(logger).EnableSensitiveDataLogging(true)    // Loga sql executado no terminal
                // .UseLazyLoadingProxies()
                .UseSqlServer(builder.ConnectionString));

            #region redis
            var builderRedis = configuration.GetConnectionString("ConexaoRedis")
                .Replace("REDIS_SECRETY_DATABASE", configuration["REDIS_SECRETY_DATABASE"]);

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = builderRedis;
                options.InstanceName = "WebStore";
            });
            #endregion

            //#region identity
            //services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();//todo
            //#endregion

            return services;
        }
    }
}
