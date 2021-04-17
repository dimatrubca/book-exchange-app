using BookExchange.Domain;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Parameters;
using BookExchange.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Service.Services
{
     class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Book>>
     {
          private readonly IBookRepository _bookRepository;

          public GetBooksQueryHandler(IBookRepository bookRepository)
          {
               _bookRepository = bookRepository;
          }

          public Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
          {
               Expression<Func<Book, bool>> predicate = (b => b.Details.PageCount >= request.MinBookPageCount
                                                                 && b.Details.PageCount <= request.MaxBookPageCount);
               if (!string.IsNullOrEmpty(request.Title))
                    predicate = predicate.AndAlso(b => b.Title.Contains(request.Title));

               if (!string.IsNullOrEmpty(request.ISBN))
                    predicate = predicate.AndAlso(b => b.ISBN.Equals(request.ISBN));

               if (!string.IsNullOrEmpty(request.Category))
                    predicate = predicate.AndAlso(b => b.Categories.Any(c => c.Label.Contains(request.Category, StringComparison.InvariantCultureIgnoreCase)));

               var books = _bookRepository.GetBooksByCondition(predicate);

               return Task.FromResult(books);
          }
     }
}
