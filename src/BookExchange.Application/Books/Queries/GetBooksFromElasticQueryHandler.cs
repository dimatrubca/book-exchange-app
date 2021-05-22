using AutoMapper;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
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
     public class GetBooksFromElasticQueryHandler : IRequestHandler<GetBooksFromElasticQuery, PagedResponse<BookDto>>
     {
          private readonly IElasticBookRepository _elasticBookRepository;
          private readonly IBookRepository _bookRepository;
          private readonly IMapper _mapper;

          public GetBooksFromElasticQueryHandler(IElasticBookRepository elasticBookRepository, IBookRepository bookRepository, IMapper mapper)
          {
               _elasticBookRepository = elasticBookRepository;
               _bookRepository = bookRepository;
               _mapper = mapper;
          }

          public async Task<PagedResponse<BookDto>> Handle(GetBooksFromElasticQuery request, CancellationToken cancellationToken)
          {
               var bookIds = await _elasticBookRepository.Get(request.searchTerm, 1, 10);

               var books = _bookRepository.GetBooksWithIds(bookIds);
               var bookDtos = _mapper.Map<List<BookDto>>(books);

               var response = new PagedResponse<BookDto>(bookDtos, request.PageNumber, request.PageSize);

               return response;
          }
     }
}
