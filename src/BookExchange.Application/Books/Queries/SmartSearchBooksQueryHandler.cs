using AutoMapper;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using BookExchange.Domain.ReadModel;
using BookExchange.Domain.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Queries
{
     public class SmartSearchBooksQueryHandler : IRequestHandler<SmartSearchBooksQuery, PagedResponse<BookDto>>
     {
          private readonly IReadModelBookRepository _bookReadRepository;
          private readonly IBookRepository _bookRepository;
          private readonly IMapper _mapper;

          public SmartSearchBooksQueryHandler(IReadModelBookRepository elasticBookRepository, IBookRepository bookRepository, IMapper mapper)
          {
               _bookReadRepository = elasticBookRepository;
               _bookRepository = bookRepository;
               _mapper = mapper;
          }

          public async Task<PagedResponse<BookDto>> Handle(SmartSearchBooksQuery request, CancellationToken cancellationToken)
          {
               var bookIds = await _bookReadRepository.Get(request.SearchTerm, 1, 10);

               var books = _bookRepository.GetBooksWithIds(bookIds);
               var bookDtos = _mapper.Map<List<BookDto>>(books);

               var response = new PagedResponse<BookDto>(bookDtos, request.PageNumber, request.PageSize);

               return response;
          }
     }
}
