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
using BookExchange.API.Configuration;
using Newtonsoft.Json;
using BookExchange.Application.Common.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Authorization;
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

               //var authOptions = services.ConfigureAuthOptions(Configuration);

               // accepts any access token issued by identity server
               services.AddAuthentication("Bearer")
                   .AddJwtBearer("Bearer", options => {
                        options.Authority = "https://localhost:5001";

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                             ValidateAudience = false
                        };
                   });

               // adds an authorization policy to make sure the token is for scope 'api1'
               services.AddAuthorization(options =>
               {
                    options.AddPolicy("ApiScope", policy =>
                    {
                         policy.RequireAuthenticatedUser();
                         policy.RequireClaim("scope", "bookApi");
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
               services.AddScoped<IRepositoryBase<Category>, RepositoryBase<Category>>();

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
               app.UseAuthorization();


               app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
               });
          }
     }
}
