using AutoMapper;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using BookExchange.Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Repositories
{
     public class PostRepository : RepositoryBase<Post>, IPostRepository
     {
          private readonly IMapper _mapper;
          public PostRepository(BookExchangeDbContext context, IMapper mapper) : base(context)
          {
               _mapper = mapper;
          }

          public PagedResponse<PostDto> GetUsersActivePosts(int userId, PaginationFilter filter)
          {
               var postsQuery = _entitites.Where(x => x.PostedById == userId)
                                          .Where(x => x.Status == PostStatus.Active)
                                          .Include(x => x.Book).ThenInclude(x => x.Authors)
                                          .Include(x => x.Book).ThenInclude(x => x.Categories)
                                          .Include(x => x.PostedBy);

               var result = postsQuery.CreatePaginatedResponse<Post, PostDto>(null, null, filter, _mapper);

               return result;
          }

          public PagedResponse<PostDto> GetUsersRequestedPosts(int userId, PaginationFilter filter)
          {
               var postsQuery = _entitites.Where(x => x.Status == PostStatus.Active)
                                             .Join(_context.Requests.Where(x => x.Status == RequestStatus.Pending)
                                                                      .Where(x => x.UserId == userId),
                                                       p => p.Id, r => r.PostId,  (p, r) => p);

               var result = postsQuery.CreatePaginatedResponse<Post, PostDto>(null, null, filter, _mapper);

               return result;
          }
/*
          public PagedResponse<PostDto> GetUsersPostRequests(int userId, PaginationFilter filter)
          {
               var postsQuery = _entities.Where(x => x.Status == PostStatus.Active)
                                             .Where(

               var result = postsQuery.CreatePaginatedResponse<Post, PostDto>(null, null, fitler, _mapper);
          }

          public PagedResponse<PostDto> */

     }
}
