using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Authors.Queries
{
     public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<Author>>
     {
          private readonly IRepositoryBase<Author> _authorsRepository;

          public GetAuthorsQueryHandler(IRepositoryBase<Author> authorsRepository)
          {
               _authorsRepository = authorsRepository;
          }

          public Task<List<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
          {
               var predicates = new List<Expression<Func<Author, bool>>>();

               if (request.Name != null)
                    predicates.Add(a => a.Name.Contains(request.Name));

               var authors = _authorsRepository.GetAllByConditions(predicates, null, Domain.Filter.LogicalOperator.And);

               return Task.FromResult(authors);
          }
     }
}
