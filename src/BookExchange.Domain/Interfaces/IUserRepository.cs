using AutoMapper;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Interfaces
{
     public interface IUserRepository : IRepositoryBase<User>
     {
          public User GetUserByIdentityId(string id);
          public PagedResponse<BookDto> GetWishedBooks(int id, PaginationFilter filter, IMapper mapper);
          public UserStatsDto GetUserStats(int id);
          public List<User> GetTopUsers(int topN);
     }
}
