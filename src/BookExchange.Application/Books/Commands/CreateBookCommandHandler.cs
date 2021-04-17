using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Books.Commands
{
     class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
     {
          private readonly IBookRepository _bookRepository;
          private readonly IRepositoryBase<BookDetails> _bookDetailsRepository;
          private readonly IRepositoryBase<Author> _bookAuthorsRepository;
          private readonly IRepositoryBase<BookCategory> _bookCategoriesRepository;

          public CreateBookCommandHandler(IBookRepository bookRepository, IRepositoryBase<BookDetails> bookDetailsRepository,
               IRepositoryBase<Author> bookAuthorsRepository, IRepositoryBase<BookCategory> bookCategoriesRepository)
          {
               _bookRepository = bookRepository;
               _bookDetailsRepository = bookDetailsRepository;
               _bookAuthorsRepository = bookAuthorsRepository;
               _bookCategoriesRepository = bookCategoriesRepository;
          }

          public Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
          {
               if (CheckBookWithIsbnExists(request.ISBN)) {
                    return Task.FromResult<Book>(null);
               }

               var book = new Book
               {
                    Title = request.Title,
                    ISBN = request.ISBN,
                    ShortDescription = request.ShortDescription,
                    Authors = request.AuthorsIds.Select(id => _bookAuthorsRepository.GetById(id)).ToList(),
                    Categories = request.CategoriesIds.Select(id => _bookCategoriesRepository.GetById(id)).ToList(),
                    Details = new BookDetails
                    {
                         Description = request.Description,
                         Publisher = request.Publisher,
                         PublishedOn = request.PublishedOn,
                         PageCount = request.PageCount
                    }
               };

               _bookRepository.Add(book);
               _bookRepository.SaveAll();
               return Task.FromResult(book);
          }

          public bool CheckBookWithIsbnExists(string ISBN) 
          {
               return _bookRepository.GetBooksByCondition(b => b.ISBN == ISBN).Any();
          }
     }
}
