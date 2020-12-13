using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.extensions
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfigure(this IServiceCollection services)
        {
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
                //c.AddSecurityDefinition("Bearrer", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.Http,
                //    Flows = new OpenApiSecurityScheme
                //    {
                        
                //            //AuthorizationUrl = new Uri("/api/Auth/login", UriKind.Relative),
                //    }
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                //        },
                //        new[] { "readAccess", "writeAccess" }
                //    }
                //});
            });
        }
    }
}
