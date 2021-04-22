using AutoMapper;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Commands
{
     public class ReplaceBookCommandHandler : IRequestHandler<ReplaceBookCommand, Book>
     {
          private readonly IBookRepository _bookRepository;
          private readonly IMapper _mapper;

          public ReplaceBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
          {
               _bookRepository = bookRepository;
               _mapper = mapper;
          }

          public Task<Book> Handle(ReplaceBookCommand request, CancellationToken cancellationToken)
          {
               var book = _bookRepository.GetById(request.Id);

               if (book != null)
               {
                    _bookRepository.Delete(book.Id);
               }

               _bookRepository.SaveAll();
               book = _mapper.Map<Book>(request);
               _bookRepository.Add(book);
               _bookRepository.SaveAllWithIdentityInsert();

               return Task.FromResult(book);
          }
     }
}
