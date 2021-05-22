using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using BookExchange.Services;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookExchange.API
{
     public class Program
     {
          public static void Main(string[] args) {
               var host = CreateHostBuilder(args).Build();

               using (var scope = host.Services.CreateScope())
               {
                    var serviceProvider = scope.ServiceProvider;
                    DataInitializer.SeedDatabase();
               }

               host.Run();
          }


          public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => {
                         webBuilder.UseStartup<Startup>();
                    })
                    .ConfigureLogging((hostingContext, logging) => {
                         logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                         logging.AddConsole();
                         logging.AddDebug();
                         logging.AddEventSourceLogger();
                    });
     }
}
