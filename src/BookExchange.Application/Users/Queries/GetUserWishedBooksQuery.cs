using BookExchange.Domain.DTOs;
using BookExchange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Queries
{
     public class GetUserWishedBooksQuery : PaginatedQueryBase<BookDto>
     {
          public int UserId { get; set; }
     }
}
