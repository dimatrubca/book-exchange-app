using BookExchange.Domain.DTOs;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using BookExchange.Domain.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Queries
{
     public class GetBooksFromElasticQueryHandler : IRequestHandler<GetBooksFromElasticQuery, PagedResponse<List<ElasticBook>>>
     {
          private readonly IElasticBookRepository _bookRepository;

          public GetBooksFromElasticQueryHandler(IElasticBookRepository bookRepository)
          {
               _bookRepository = bookRepository;
          }

          async Task<PagedResponse<List<ElasticBook>>> IRequestHandler<GetBooksFromElasticQuery, PagedResponse<List<ElasticBook>>>.Handle(GetBooksFromElasticQuery request, CancellationToken cancellationToken)
          {
               var response = await _bookRepository.Get(request.searchTerm, 1, 10);

               return response;
          }
     }
}
