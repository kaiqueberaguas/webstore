using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Src.Extensions
{
    public static class ExceptionHandlerExtension
    {//analisar

        public static readonly ILoggerFactory loggerFactoryk = LoggerFactory.Create(builder => builder.AddConsole());

        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var logger = loggerFactoryk.CreateLogger("GlobalExceptionHandler");
                        logger.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");

                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var json = new
                        {
                            context.Response.StatusCode,
                            Message = "Ops, ocorreu algum erro, tente novamente mais tarde!",
                            Detailed = exceptionHandlerFeature.Error.Message
                        };

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
                    }
                });
            });
        }
    }
}
