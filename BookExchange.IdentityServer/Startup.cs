using BookExchange.IdentityServer.Identity;
using BookExchange.IdentityServer.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.IdentityServer
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

               services.AddControllers();
               services.AddSwaggerGen(c => {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookExchange.IdentityServer", Version = "v1" });
               });


               services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("IdentityDatabase"),
                    x => x.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

               services.AddScoped<IProfileService, IdentityProfileService>();


               services.AddIdentity<ApplicationIdentityUser, IdentityRole>(options => {
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
               }).AddEntityFrameworkStores<IdentityContext>()
                 .AddDefaultTokenProviders();

               services.AddIdentityServer(options => {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
               })
                  .AddDeveloperSigningCredential()        //This is for dev only scenarios when you don’t have a certificate to use.
                  .AddInMemoryIdentityResources(Config.IdentityResources)
                  .AddInMemoryApiResources(Config.ApiResources)
                  .AddInMemoryApiScopes(Config.ApiScopes)
                  .AddInMemoryClients(Config.Clients)
                  .AddAspNetIdentity<ApplicationIdentityUser>()
                  .AddProfileService<IdentityProfileService>();

               services.AddAuthentication();
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, UserManager<ApplicationIdentityUser> userManager*/)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookExchange.IdentityServer v1"));
               }



               app.UseHttpsRedirection();

               app.UseRouting();

               app.UseIdentityServer();

               app.UseAuthorization();

               app.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
               });

               //IdentityDataSeeder.SeedAll(userManager);
          }
     }
}
