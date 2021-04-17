using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Commands
{
     class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
     {
          private readonly IBookRepository _bookRepository;
          private readonly IRepositoryBase<Author> _bookAuthorsRepository;
          private readonly IRepositoryBase<BookCategory> _bookCategoriesRepository;

          public UpdateBookCommandHandler(IBookRepository bookRepository, IRepositoryBase<Author> bookAuthorsRepository, IRepositoryBase<BookCategory> bookCategoriesRepository)
          {
               _bookRepository = bookRepository;
               _bookAuthorsRepository = bookAuthorsRepository;
               _bookCategoriesRepository = bookCategoriesRepository;
          }

          public Task<Book> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
          {
               var book = _bookRepository.GetByIdWithInclude(command.Id, b => b.Details, b => b.Authors, b => b.Categories);

               if (book == null)
               {
                    return Task.FromResult<Book>(null);
               }

               if (!string.IsNullOrWhiteSpace(command.Title))
                    book.Title = command.Title;

               if (!string.IsNullOrWhiteSpace(command.ShortDescription))
                    book.ShortDescription = command.ShortDescription;

               if (!string.IsNullOrWhiteSpace(command.ISBN))
                    book.ISBN = command.ISBN;

               if (!string.IsNullOrWhiteSpace(command.Description))
                    book.Details.Description = command.Description;

               if (!string.IsNullOrWhiteSpace(command.Publisher))
                    book.Details.Publisher = command.Publisher;

               if (command.PublishedOn != null)
                    book.Details.PublishedOn = command.PublishedOn;

               if (command.AuthorsIds != null)
                    command.AuthorsIds.ForEach(id => {
                         var author = _bookAuthorsRepository.GetById(id);

                         if (author != null) {
                              book.Authors.Add(author);
                         }
                    });

               if (command.CategoriesIds != null)
                    command.CategoriesIds.ForEach(id => {
                         var category = _bookCategoriesRepository.GetById(id);

                         if (category != null) {
                              book.Categories.Add(category);
                         }
                    });

               _bookRepository.SaveAll();

               return Task.FromResult<Book>(book);
          }

     }
}
