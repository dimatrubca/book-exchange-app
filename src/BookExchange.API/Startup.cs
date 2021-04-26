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

               services.AddIdentity<ApplicationUser, Role>(options => {
                    options.Password.RequiredLength = 8;
               }).AddEntityFrameworkStores<BookExchangeDbContext>();

               var authOptions = services.ConfigureAuthOptions(Configuration);
               services.AddJwtAuthentication(authOptions);
               services.AddControllers(options => {
                    options.Filters.Add(new AuthorizeFilter());
               });
               /*
               services.AddIdentity<ApplicationUser, Role>(options => {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredLength = 5;
               }).AddEntityFrameworkStores<BookExchangeDbContext>()
                    .AddDefaultTokenProviders();


               // configure jwt authentication
               services.AddAuthentication(auth => {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer(options => {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidAudience = "http://example.com",
                         ValidIssuer = "http://example.com",
                         RequireExpirationTime = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the key")),
                         ValidateIssuerSigningKey = true
                    };
               });*/

               services.AddSingleton<ILogger>(svc => svc.GetRequiredService<ILogger<RequestTimeMiddleware>>());

               services.AddScoped<DbContext, BookExchangeDbContext>();
               services.AddScoped<IBookRepository, BookRepository>();
               services.AddScoped<IUserRepository, UserRepository>();
               services.AddScoped<IPostRepository, PostRepository>();

               services.AddScoped<IRepositoryBase<Author>, RepositoryBase<Author>>();
               services.AddScoped<IRepositoryBase<BookDetails>, RepositoryBase<BookDetails>>();
               services.AddScoped<IRepositoryBase<BookCategory>, RepositoryBase<BookCategory>>();

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


               app.UseRequestTime();

               app.UseHttpsRedirection();


               app.UseRouting();

               app.UseAuthentication();
               app.UseAuthorization();
               app.UseStaticFiles();


               app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
               });
          }
     }
}
