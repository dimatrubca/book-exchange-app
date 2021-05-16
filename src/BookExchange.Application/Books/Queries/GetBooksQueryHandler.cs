using AutoMapper;
using BookExchange.Domain;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Parameters;
using BookExchange.Domain.Queries;
using BookExchange.Domain.Wrappers;
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
     public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedResponse<List<BookDto>>>
     {
          private readonly IBookRepository _bookRepository;
          private readonly IMapper _mapper;

          public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
          {
               _bookRepository = bookRepository;
               _mapper = mapper;
          }

          public Task<PagedResponse<List<BookDto>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
          {
               var includes = new List<Expression<Func<Book, Object>>>
               { 
                    b => b.Categories,
                    b => b.Authors
               };

               var predicates = new List<Expression<Func<Book, bool>>>
               {
                    b => b.Details.PageCount >= request.MinPageCount,
                    b => b.Details.PageCount <= request.MaxPageCount
               };


               if (!string.IsNullOrEmpty(request.Title))
                    predicates.Add(b => b.Title.Contains(request.Title));

               if (!string.IsNullOrEmpty(request.ISBN))
                    predicates.Add(b => b.ISBN.Equals(request.ISBN));

               if (!string.IsNullOrEmpty(request.Category))
                    predicates.Add(b => b.Categories.Any(c => c.Label.Contains(request.Category, StringComparison.InvariantCultureIgnoreCase)));
 
               if (!string.IsNullOrEmpty(request.Publisher))
                    predicates.Add(b => b.Details.Publisher.Contains(request.Publisher));
                    includes.Add(b => b.Details);

               var paginationRequestFilter = _mapper.Map<PaginationRequestFilter>(request);

               var books = _bookRepository.GetPagedData<BookDto>(predicates, includes, paginationRequestFilter, _mapper);

               return Task.FromResult(books);
          }
     }
}
