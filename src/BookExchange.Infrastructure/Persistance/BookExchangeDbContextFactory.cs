using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance
{
     public class BookExchangeDbContextFactory : IDesignTimeDbContextFactory<BookExchangeDbContext>
     {
          public BookExchangeDbContext CreateDbContext(string[] args)
          {
               var optionsBuilder = new DbContextOptionsBuilder<BookExchangeDbContext>();
               IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();

               optionsBuilder
                    .UseSqlServer(configuration.GetConnectionString("BookExchangaDatabase"));

               return new BookExchangeDbContext(optionsBuilder.Options);
          }
     }
}
