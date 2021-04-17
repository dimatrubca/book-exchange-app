using BookExchange.Domain.DTOs;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Service.Services
{
     class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book>
     {
          private readonly IBookRepository _bookRepository;

          public GetBookQueryHandler(IBookRepository bookRepository)
          {
               _bookRepository = bookRepository;
          }

          public Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
          {
               Book book;

               if (!request.IncludeDetails) {
                    book = _bookRepository.GetById(request.Id);
               } else {
                    book = _bookRepository.GetByIdWithInclude(request.Id, b => b.Details);
               }

               return Task.FromResult(book);
          }
     }
}
