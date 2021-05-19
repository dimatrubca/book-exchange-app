using AutoMapper;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
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
          private readonly IElasticBookRepository _elasticBookRepository;
          private readonly IMapper _mapper;

          public BookCreatedEventHandler(IElasticBookRepository elasticBookRepository, IMapper mapper)
          {
               _elasticBookRepository = elasticBookRepository;
               _mapper = mapper;
          }

          public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
          {
               var book = _mapper.Map<ElasticBook>(notification);

               _elasticBookRepository.AddAsync(book);

               return Task.CompletedTask;
          }
     }
}
