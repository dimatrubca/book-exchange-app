using BookExchange.Domain.Commands;
using BookExchange.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Commands
{
     class DeleteBookByIdHandler : IRequestHandler<DeleteBookByIdCommand, bool>
     {
          private readonly IBookRepository _bookRepository;

          public DeleteBookByIdHandler(IBookRepository bookRepository)
          {
               _bookRepository = bookRepository;
          }

          public Task<bool> Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
          {
               var book = _bookRepository.Delete(command.Id);
               _bookRepository.SaveAll();

               return Task.FromResult(book != null);
          }
     }
}
