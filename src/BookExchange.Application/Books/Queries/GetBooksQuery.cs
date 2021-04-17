using BookExchange.Domain.Models;
using BookExchange.Domain.Parameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookExchange.Domain.Queries
{
     public class GetBooksQuery : IRequest<List<Book>>
     {
          public bool IncludeDetails { get; set; }

          // filter options:
          public string ISBN { get; set; }
          public string Title { get; set; }
          public string Author { get; set; }
          public string Category { get; set; }
          public int MinBookPageCount { get; set; }
          public int MaxBookPageCount { get; set; } = int.MaxValue;
     }
}
