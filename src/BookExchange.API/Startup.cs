using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Infrastructure.Persistance;
using BookExchange.Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Buffers;
using BookExchange.API.Configuration;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Configuration;
using Newtonsoft.Json;
using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Authorization;
using BookExchange.Application.Common.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BookExchange.API.Identity;
using IdentityUser = BookExchange.API.Identity.IdentityUser;
using IdentityServer4;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IdentityServer4.Services;
using BookExchange.Infrastructure.ElasticSearch;
using BookExchange.Infrastructure.ElasticSearch.Repositories;

namespace BookExchange.API
{
     public class Startup
     {
          public Startup(IConfiguration configuration)
          {
               Configuration = configuration;
          }

          public IConfiguration Configuration { get; }

          // This method gets called by the runtime. Use this method to add services to the container.
          public void ConfigureServices(IServiceCollection services)
          {
               services.AddControllers().AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               });

               services.AddSwaggerGen(c => {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookExchange", Version = "v1" });

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                         In = ParameterLocation.Header,
                         Description = "Please insert JWT with Bearer into field",
                         Name = "Authorization",
                         Type = SecuritySchemeType.ApiKey
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                       {
                         new OpenApiSecurityScheme
                         {
                           Reference = new OpenApiReference
                           {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                           }
                          },
                          new string[] { }
                        }
                      });
               });

               services.AddMvc(
                    config => {
                         config.Filters.Add(typeof(ApiExceptionFilter));
                    }
               );

               services.AddDbContext<BookExchangeDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BookExchangaDatabase"),
                    x => x.MigrationsAssembly(typeof(BookExchangeDbContext).Assembly.FullName)));

               services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("IdentityDatabase"),
                    x => x.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

               services.AddScoped<IProfileService, IdentityProfileService>();


               services.AddIdentity<IdentityUser, IdentityRole>(options => {
                         options.Password.RequiredLength = 5;
               }).AddEntityFrameworkStores<IdentityContext>()
                 .AddDefaultTokenProviders();

               services.AddIdentityServer(options => {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://identityserver4.readthedoc
               })//.AddApiAuthorization<IdentityUser, IdentityContext>()


                  .AddDeveloperSigningCredential()        //This is for dev only scenarios when you don’t have a certificate to use.
                  .AddInMemoryIdentityResources(Config.IdentityResources)
                  .AddInMemoryApiResources(Config.ApiResources)
                  .AddInMemoryApiScopes(Config.ApiScopes)
                  .AddInMemoryClients(Config.Clients)
                   //.AddTestUsers(TestUsers.Users);
                   .AddAspNetIdentity<IdentityUser>()
                                       .AddProfileService<IdentityProfileService>();




               var authOptions = services.ConfigureAuthOptions(Configuration);
               //     // services.AddAuthentication(options => {
               //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               //})
               //    /*.AddGoogle(options => {
               //         options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

               //      // register your IdentityServer with Google at https://console.developers.google.com
               //      // enable the Google+ API
               //      // set the redirect URI to https://localhost:5001/signin-google
               //      options.ClientId = "copy client ID from Google here";
               //         options.ClientSecret = "copy client secret from Google here";
               //    })
               //  .AddIdentityServerAuthentication();
               /*   .AddJwtBearer(options =>
                  {
                       options.Audience = "https://localhost:5001";
                       options.Authority = "https://localhost:5001";
                       options.RequireHttpsMetadata = false;
                       options.Audience = "client";
                  });*/
               //  .AddLocalApi();
               /*
                            services.AddAuthentication()
                   .AddJwtBearer(jwt => {
                                 jwt.Authority = "https://localhost:5001";
                                 jwt.RequireHttpsMetadata = false;
                                 jwt.Audience = "bookApiResource";
                            });*/
               services.AddAuthentication()
       .AddLocalApi();

               services.AddAuthorization(options =>
               {
                    options.AddPolicy(IdentityServerConstants.LocalApi.PolicyName, policy =>
                    {
                         policy.AddAuthenticationSchemes(IdentityServerConstants.LocalApi.AuthenticationScheme);
                         policy.RequireAuthenticatedUser();
                    });
               });


               //services.AddJwtAuthentication(authOptions);

               services.AddHttpContextAccessor();

               services.AddControllers(options => {
                    options.Filters.Add(new AuthorizeFilter());
               });

               services.AddSingleton<ILogger>(svc => svc.GetRequiredService<ILogger<RequestTimeMiddleware>>());

               services.AddElasticSearch(Configuration);


               services.AddScoped<DbContext, BookExchangeDbContext>();
               services.AddScoped<IBookRepository, BookRepository>();
               services.AddScoped<IUserRepository, UserRepository>();
               services.AddScoped<IPostRepository, PostRepository>();

               services.AddScoped<IRepositoryBase<Author>, RepositoryBase<Author>>();
               services.AddScoped<IRepositoryBase<BookDetails>, RepositoryBase<BookDetails>>();
               services.AddScoped<IRepositoryBase<BookCategory>, RepositoryBase<BookCategory>>();

               services.AddScoped<IElasticBookRepository, ElasticBookRepository>();

               services.AddMediatR(typeof(Application.Class1));
               services.AddAutoMapper(typeof(Application.Common.Mappings.MappingProfile).Assembly);

          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {


               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookExchange v1"));
               }
               
               app.UseHttpsRedirection();

               app.UseStaticFiles();
               app.UseRouting();
               app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

               app.UseAuthentication();
               app.UseIdentityServer();
               app.UseAuthorization();


               app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
               });
          }
     }
}
