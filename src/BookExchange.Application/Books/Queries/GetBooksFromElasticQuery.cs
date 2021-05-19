using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Queries
{
     public class GetBooksFromElasticQuery : PaginatedQueryBase<ElasticBook>
     {
          public string searchTerm { get; set; }
     }
}
