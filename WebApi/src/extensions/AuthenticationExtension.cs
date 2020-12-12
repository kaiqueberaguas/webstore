//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using System;

//namespace webApi.src.extensions
//{
//    public static class AuthenticationExtension
//    {
//        public static IServiceCollection AddJwtSecurity(this IServiceCollection services,IConfiguration configuration)
//        {
           
//            var signingConfigurations = new SigningConfigurations(configuration);
//            var tokenConfigurations = new TokenConfigurations();
            
//            new ConfigureFromConfigurationOptions<TokenConfigurations>(
//                configuration.GetSection("TokenConfigurations"))
//                    .Configure(tokenConfigurations);

//            services.AddSingleton(signingConfigurations);
//            services.AddSingleton(tokenConfigurations);
            
//            services.AddAuthentication(authOptions =>
//            {
//                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            }).AddJwtBearer(bearerOptions =>
//            {
//                var paramsValidation = bearerOptions.TokenValidationParameters;
//                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
//                paramsValidation.ValidAudience = tokenConfigurations.Audience;
//                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
//                paramsValidation.ValidateIssuerSigningKey = true;
//                paramsValidation.ValidateLifetime = true;
//                paramsValidation.ClockSkew = TimeSpan.Zero;
                
//                //bearerOptions.Events = new JwtBearerEvents()
//                //{
//                //    OnAuthenticationFailed = c => 
//                //    {
//                //        c.NoResult();
//                //        c.Response.StatusCode = 500;
//                //        c.Response.ContentType = "text/plain";
//                //        c.Response.WriteAsync(c.Exception.ToString());
//                //        return Task.CompletedTask;
//                //    },
//                //    OnMessageReceived = context => Task.CompletedTask
//                //};

//            });

//            services.AddAuthorization(auth =>
//            {
//                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
//                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
//                    .RequireAuthenticatedUser().Build());
//            });
//            return services;
//        }
//    }
//}
