using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Events
{
     class BookCreatedEventHandler : INotificationHandler<BookCreatedEvent>
     {
          public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
          {
               Console.WriteLine("Inside BookCreatedEventHandler");

               return Task.CompletedTask;
          }
     }
}
