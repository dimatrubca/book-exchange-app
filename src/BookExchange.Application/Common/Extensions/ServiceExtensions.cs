using BookExchange.Application.Common.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Application.Common.Extensions
{
     public static class ServiceExtensions
     {

          public static void AddJwtAuthentication(this IServiceCollection services, AuthOptions authOptions)
          {
               services.AddAuthentication(options =>
               {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer(options =>
               {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                         ValidateIssuer = true,
                         ValidIssuer = authOptions.Issuer,

                         ValidateAudience = true,
                         ValidAudience = authOptions.Audience,

                         ValidateLifetime = true,

                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                    };
               });
          }

          public static AuthOptions ConfigureAuthOptions(this IServiceCollection services, IConfiguration configuration)
          {
               var authOptionsConfigurationSection = configuration.GetSection(AuthOptions.Auth);
               services.Configure<AuthOptions>(authOptionsConfigurationSection);
               var authOptions = authOptionsConfigurationSection.Get<AuthOptions>();
               return authOptions;
          }
     }
}

