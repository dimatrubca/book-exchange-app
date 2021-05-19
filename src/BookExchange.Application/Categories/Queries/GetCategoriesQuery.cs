using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Categories.Queries
{
     public class GetCategoriesQuery : IRequest<List<BookCategory>>
     {
     }
}
