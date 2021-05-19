using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Authors.Queries
{
     public class GetAuthorsQuery : IRequest<List<Author>>
     {
          public string Name { get; set; }
     }
}
