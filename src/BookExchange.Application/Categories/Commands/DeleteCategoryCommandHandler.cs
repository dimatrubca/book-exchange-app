using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Categories.Commands
{
     public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
     {
          private readonly ICategoryRepository _categoriesRepository;

          public DeleteCategoryCommandHandler(ICategoryRepository categoriesRepository)
          {
               _categoriesRepository = categoriesRepository;
          }

          public Task<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
          {
               var category = _categoriesRepository.Delete(command.Id);
               _categoriesRepository.SaveAll();

               if (category == null)
               {
                    throw new NotFoundException(nameof(Author), command.Id);
               }

               return Task.FromResult(Unit.Value);
          }
     }
}
