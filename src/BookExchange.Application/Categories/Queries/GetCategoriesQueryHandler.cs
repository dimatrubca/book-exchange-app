using BookExchange.Domain.DTOs;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Categories.Queries
{
     public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<BookCategory>>
     {
          private readonly IRepositoryBase<BookCategory> _categoriesRepository;

          public GetCategoriesQueryHandler(IRepositoryBase<BookCategory> categoriesRepository)
          {
               _categoriesRepository = categoriesRepository;
          }

          public Task<List<BookCategory>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
          {
               return Task.FromResult(_categoriesRepository.GetAll());
          }
     }
}
