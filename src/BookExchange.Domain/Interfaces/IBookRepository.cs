using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookExchange.Domain.Interfaces
{
     public interface IBookRepository : IRepositoryBase<Book>
     {
          public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> predicate);
     }
}