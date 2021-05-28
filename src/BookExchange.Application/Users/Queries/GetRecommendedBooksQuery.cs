using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Users.Queries
{
     public class GetRecommendedBooksQuery : IRequest<List<Book>>
     {
          public int Id { get; set; }
          public int TopN { get; set; }
     }
}
