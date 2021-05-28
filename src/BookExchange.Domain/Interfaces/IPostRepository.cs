using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Domain.Interfaces
{
     public interface IPostRepository : IRepositoryBase<Post>
     {
          public PagedResponse<PostDto> GetUsersActivePosts(int userId, PaginationFilter filter);
     }
}
