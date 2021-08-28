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
using System.Text;
using BookExchange.Infrastructure.Persistance.Extensions;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class UserRepository : RepositoryBase<User>, IUserRepository
     {
          public UserRepository(BookExchangeDbContext context) : base(context)
          {
          }

          public User GetUserByIdentityId(string id)
          {
               return GetAllByConditionWithInclude(u => u.IdentityId == id, u => u.UserContact).Single();
          }

          public PagedResponse<BookDto> GetWishedBooks(int id, PaginationFilter filter, IMapper mapper)
          {
               var user = GetById(id);
               var booksQuery = _context.Entry(user).Collection(b => b.WishedBooks).Query()
                                   .Include(b => b.Authors)
                                   .Include(b => b.Categories);

               return booksQuery.CreatePaginatedResponse<Book, BookDto>(null, null, filter, mapper);
          }
          public UserStatsDto GetUserStats(int id)
          {
               var user = GetById(id);

               return new UserStatsDto
               {
                    Wishlist = _context.Entry(user).Collection(u => u.WishedBooks).Query().Count(),
                    Bookshelf = _context.Entry(user).Collection(u => u.Posts).Query().Where(p => p.Status == PostStatus.Active).Count(),
                    Requests = _context.Entry(user).Collection(u => u.Posts).Query()
                         .Where(post => post.Status == PostStatus.Active)
                         .Join(_context.Requests.Where(r => r.Status == RequestStatus.Pending), p => p.Id, r => r.PostId, (p, r) => new { p, r })
                         .Count(),

                    Requested = _context.Entry(user).Collection(u => u.Requests).Query().Where(x => x.Status == RequestStatus.Pending).Count(),
                    Awaiting = _context.Set<Deal>().Where(x => x.BookTakerId == id && x.DealStatus == DealStatus.InDelivery).Count(),

                    Sent = _context.Posts.Where(x => x.PostedById == id)
                         .Join(_context.Deals.Where(x => x.DealStatus != DealStatus.Canceled), 
                                        p => p.Id, 
                                        d => d.PostId, 
                                        (p, d) => new { p, d })
                         .Count()
               };
          }

          public List<User> GetTopUsers(int topN)
          {
               var topUsers = _entitites.OrderByDescending(x => x.Points).Take(topN).Take(topN).ToList();

               return topUsers;
          }
     }
}
