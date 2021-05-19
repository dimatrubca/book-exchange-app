using BookExchange.Application.Common;
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
     public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BookCategory>
     {
          private readonly IRepositoryBase<BookCategory> _categoriesRepository;

          public CreateCategoryCommandHandler(IRepositoryBase<BookCategory> categoriesRepository)
          {
               _categoriesRepository = categoriesRepository;
          }

          public Task<BookCategory> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
          {
               if (ServiceUtils.CheckBookCategoryExists(_categoriesRepository, request.Label)) {
                    throw new BadRequestException($"Category with label = {request.Label} already exists");
               }

               BookCategory bookCategory = new BookCategory
               {
                    Label = request.Label
               };

               _categoriesRepository.Add(bookCategory);
               _categoriesRepository.SaveAll();

               return Task.FromResult(bookCategory);
          }
     }
}
