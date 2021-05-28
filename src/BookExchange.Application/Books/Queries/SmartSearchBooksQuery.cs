using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Queries
{
     public class SmartSearchBooksQuery : PaginatedQueryBase<BookDto>
     {
          public string SearchTerm { get; set; }
     }
}
