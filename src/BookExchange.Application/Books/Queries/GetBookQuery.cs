using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Queries
{
     public class GetBookQuery : IRequest<Book> {
          public int Id { get; set; }
          public bool IncludeDetails { get; set; }

     }
}
