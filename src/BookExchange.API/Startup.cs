using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Infrastructure.Persistance;
using BookExchange.Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Buffers;

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

               services.AddControllers().AddNewtonsoftJson(options =>
               {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               });

               services.AddSwaggerGen(c => {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookExchange", Version = "v1" });
               });

               services.AddDbContext<BookExchangeDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BookExchangaDatabase"),
                    x => x.MigrationsAssembly(typeof(BookExchangeDbContext).Assembly.FullName)));

               // add DI
               services.AddScoped<DbContext, BookExchangeDbContext>();
               services.AddScoped<IBookRepository, BookRepository>();
               services.AddScoped<IUserRepository, UserRepository>();
               services.AddScoped<IRepositoryBase<Author>, RepositoryBase<Author>>();
               services.AddScoped<IRepositoryBase<BookDetails>, RepositoryBase<BookDetails>>();
               services.AddScoped<IRepositoryBase<BookCategory>, RepositoryBase<BookCategory>>();

               services.AddMediatR(typeof(Application.Class1));
               services.AddAutoMapper(typeof(Application.Common.Mappings.MappingProfile).Assembly);
               /*var mappingConfig = new MapperConfiguration(mc => { });
               IMapper mapper = mappingConfig.CreateMapper();
               services.AddSingleton(mapper);*/
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

               app.UseRouting();

               app.UseAuthorization();

               app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
               });
          }
     }
}