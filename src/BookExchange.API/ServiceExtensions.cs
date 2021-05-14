using BookExchange.Application.Common.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace BookExchange.API
{
     public static class ServiceExtensions
     {

          public static void AddJwtAuthentication(this IServiceCollection services, AuthOptions authOptions)
          {
               services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer(options => {
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
               }).AddFacebook(options => {
                    options.AppId = "282907863514502";
                    options.AppSecret = "2743d6e9a87b3dbc54ad2fa5f639aa8d";
                    options.AccessDeniedPath = "/AccessDeniedPathInfo";
               }).AddGoogle(options => {
                    options.ClientId = "818592769964-d40iemfaml4g3eelhongq7qe999lq1o8.apps.googleusercontent.com";
                    options.ClientSecret = "krlc1avBrUCNWZ3yHqxUfYlR";
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

