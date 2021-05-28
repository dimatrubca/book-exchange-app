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
     public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedResponse<BookDto>>
     {
          private readonly IBookRepository _bookRepository;
          private readonly IMapper _mapper;

          public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
          {
               _bookRepository = bookRepository;
               _mapper = mapper;
          }

          public Task<PagedResponse<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
          {
               var includes = new List<Expression<Func<Book, Object>>>
               { 
                    b => b.Categories,
                    b => b.Authors
               };

               var predicates = new List<Expression<Func<Book, bool>>>();


               if (!string.IsNullOrEmpty(request.Title)) 
               {
                    predicates.Add(b => b.Title.Contains(request.Title));
               }

               if (!string.IsNullOrEmpty(request.ISBN))
               {
                    predicates.Add(b => b.ISBN.Equals(request.ISBN));
               }

               if (request.Categories.Count != null && request.Categories.Count != 0)
               {
                    predicates.Add(b => b.Categories.Any(c => request.Categories.Contains(c.Id)));
                    includes.Add(b => b.Categories);
               }

               if (request.Authors?.Count != 0)
               {
                    predicates.Add(b => b.Authors.Any(c => request.Authors.Contains(c.Id)));
                    includes.Add(b => b.Authors);
               }

               if (!string.IsNullOrEmpty(request.Publisher)) 
               {
                    predicates.Add(b => b.Details.Publisher.Contains(request.Publisher));
                    includes.Add(b => b.Details);
               }

               if (request.MaxPageCount != null)
               {
                    predicates.Add(b => b.Details.PageCount <= request.MaxPageCount);
                    includes.Add(b => b.Details);
               }

               if (request.MinPageCount != null)
               {
                    predicates.Add(b => b.Details.PageCount >= request.MinPageCount);
                    includes.Add(b => b.Details);
               }

               if (request.PublishedYear != null)
               {
                    predicates.Add(b => b.Details.PublishedYear == request.PublishedYear);
                    includes.Add(b => b.Details);
               }




               var paginationRequestFilter = _mapper.Map<PaginationFilter>(request);

               var books = _bookRepository.GetPagedData<BookDto>(predicates, includes, paginationRequestFilter, _mapper);

               return Task.FromResult(books);
          }
     }
}
