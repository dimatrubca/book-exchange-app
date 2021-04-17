using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class BookRepository : RepositoryBase<Book>, IBookRepository
     {
          public BookRepository(DbContext context) : base(context)
          {
          }

          public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> predicate)
          {
               return GetAllByConditionWithInclude(predicate, b => b.Details, b => b.Categories, b => b.Authors);
          }
     }
}
