using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.ReadModel;
using BookExchange.Domain.Wrappers;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.ElasticSearch.Repositories
{
     public class ElasticBookRepository : IReadModelBookRepository
     {
          private readonly IElasticClient _elasticClient;
          private readonly ILogger _logger;

          public ElasticBookRepository(IElasticClient elasticClient, ILogger logger)
          {
               _elasticClient = elasticClient;
               _logger = logger;
          }

          public async Task AddAsync(ReadModelBook book)
          {
               var response = await _elasticClient.IndexDocumentAsync(book);

               if (!response.IsValid) {
                    Console.WriteLine("Error");
               }
          }

          public async Task DeleteById(int id)
          {
               await _elasticClient.DeleteAsync<ReadModelBook>(id);
          }



          public async Task AddBulkAsync(ReadModelBook[] books)
          {
               var result = await _elasticClient.BulkAsync(b => b.Index("books").IndexMany(books));

               if (result.Errors) {
                    foreach (var item in result.ItemsWithErrors)
                    {
                         Console.WriteLine("Failed to index document {0}: {1}", item.Id, item.Error);
                    }
               }
          }

          public async Task<List<int>> Get(string query, int page, int pageSize)
          {
               var result = await _elasticClient.SearchAsync<ReadModelBook>(x => x.Query(q => q
                                                                 .MultiMatch(mp => mp
                                                                      .Query(query)
                                                                      .Fields(f => f
                                                                           .Fields(f1 => f1.Title, f2 => f2.Description, f3 => f3.Authors))))
                                                              .From(page - 1)
                                                              .Size(pageSize));

               var response = result.Documents.Select(b => b.Id).ToList();
               //result.HitsMetadata.Total
               return response;
          }
     }
}
