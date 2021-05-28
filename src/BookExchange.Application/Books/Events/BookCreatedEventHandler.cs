using AutoMapper;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.ReadModel;
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
          private readonly IReadModelBookRepository _bookReadRepository;
          private readonly IMapper _mapper;  

          public BookCreatedEventHandler(IReadModelBookRepository elasticBookRepository, IMapper mapper)
          {
               _bookReadRepository = elasticBookRepository;
               _mapper = mapper;
          }

          public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
          {
               var book = _mapper.Map<ReadModelBook>(notification);

               return _bookReadRepository.AddAsync(book);
          }
     }
}
