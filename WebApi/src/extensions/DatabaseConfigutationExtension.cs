using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webApi.src.dbcontext;

namespace webApi.src.extensions
{
    public static class DatabaseConfigutationExtension
    {
        public static IServiceCollection AddDataBaseConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            #region database_configuration
            var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString("SqlServerConnectionString"));
            builder.Password = configuration["SECRETY_DATABASE"];
            #endregion
            services.AddEntityFrameworkSqlServer().AddDbContext<StoreContext>(options => options.UseSqlServer(builder.ConnectionString));
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration =
                    configuration.GetConnectionString("ConexaoRedis");
                options.InstanceName = "APIProdutos";
            });

            #region identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();//todo
            #endregion

            return services;
        }
    }
}
