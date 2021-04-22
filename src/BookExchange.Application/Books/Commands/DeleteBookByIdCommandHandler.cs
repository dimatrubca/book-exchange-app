using BookExchange.Domain.Commands;
using BookExchange.Domain.Interfaces;
using BookExchange.Application.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookExchange.Domain.Models;

namespace BookExchange.Application.Books.Commands
{
     class DeleteBookByIdHandler : IRequestHandler<DeleteBookByIdCommand, Unit>
     {
          private readonly IBookRepository _bookRepository;

          public DeleteBookByIdHandler(IBookRepository bookRepository)
          {
               _bookRepository = bookRepository;
          }

          public Task<Unit> Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
          {
               var book = _bookRepository.Delete(command.Id);
               _bookRepository.SaveAll();

               if (book == null)
               {
                    throw new NotFoundException(nameof(Book), command.Id);
               }

               return Task.FromResult(Unit.Value);
          }
     }
}
