using AutoMapper;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class BookRepository : RepositoryBase<Book>, IBookRepository
     {
          public BookRepository(BookExchangeDbContext context) : base(context)
          {

          }

          public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> predicate)
          {
               return GetAllByConditionWithInclude(predicate, b => b.Details, b => b.Categories, b => b.Authors);
          }

          public List<Book> GetBooksWithIds(List<int> idList)
          {
               return _entitites.Include(b => b.Details).Include(b => b.Authors).Include(b => b.Categories)
                              .Where(b => idList.Contains(b.Id)).AsEnumerable().OrderBy(x => idList.IndexOf(x.Id)).ToList();
          }


     }
}
