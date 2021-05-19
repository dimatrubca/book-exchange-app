using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.Interfaces
{
     public interface IElasticBookRepository
     {
          public Task AddAsync(ElasticBook book);
          public Task DeleteById(int id);
          public Task AddBulkAsync(ElasticBook[] books);
          public Task<PagedResponse<ElasticBook>> Get(string query, int page, int pageSize);


     }
}
