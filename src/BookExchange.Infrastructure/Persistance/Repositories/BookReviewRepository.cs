using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class BookReviewRepository : RepositoryBase<BookReview>, IBookReviewRepository
     {
          public BookReviewRepository(BookExchangeDbContext context) : base(context)
          {
          }

          public List<BookReview> GetUserBookReviews(int userId)
          {
               var bookReviews = _context.Set<BookReview>().Where(x => x.UserId == userId).Include(x => x.Book).ThenInclude(x => x.Categories);

               return bookReviews.ToList();
          }
     }
}
