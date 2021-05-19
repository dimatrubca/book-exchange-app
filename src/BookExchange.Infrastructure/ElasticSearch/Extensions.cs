using BookExchange.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.ElasticSearch
{
     public static class Extensions
     {
          public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
          {
               var url = configuration["elasticsearch:url"];
               var defaultIndex = configuration["elasticsearch:index"];



               var settings = new ConnectionSettings(new Uri(url))
                    .DefaultIndex(defaultIndex);

               AddDefaultMappings(settings);

               var client = new ElasticClient(settings);

               services.AddSingleton<IElasticClient>(client);

               CreateIndex(client, defaultIndex);
          }

          private static void AddDefaultMappings(ConnectionSettings settings)
          {
               settings.DefaultMappingFor<ElasticBook>(m => m);
          }

          private static void CreateIndex(IElasticClient client, string indexName)
          {
               var createIndexResponse = client.Indices.Create(indexName, index => index.Map<ElasticBook>(x => x.AutoMap()));
          }
     }
}
