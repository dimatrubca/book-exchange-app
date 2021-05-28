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
     public class RequestRepository : RepositoryBase<Request>, IRequestRepository
     {
          private readonly IMapper _mapper;
          public RequestRepository(BookExchangeDbContext context, IMapper mapper) : base(context)
          {
               _mapper = mapper;
          }

         /* public PagedResponse<PostDto> GetPostRequests(int id, PaginationFilter filter, IMapper mapper)
          {
               var posts = _entitites.Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Authors)
                                        .Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Categories)
                                        .Where(x => x.Post.PostedById == id)
                                        .Where(x => x.Status == RequestStatus.Pending);

               return posts.CreatePaginatedResponse<Post, PostDto>(null, null, filter, mapper);
          }

          public PagedResponse<PostDto> GetRequestedPosts(int id, PaginationFilter filter, IMapper mapper)
          {
               var posts = _entitites.Where(x => x.UserId == id && x.Status == RequestStatus.Pending)
                    .Include(x => x.Post).ThenInclude(x => x.PostedBy)
                    .Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Authors)
                    .Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Categories)
                    .Select(x => x.Post);

               return posts.CreatePaginatedResponse<Post, PostDto>(null, null, filter, mapper);
          }*/

          public PagedResponse<RequestDto> GetRequestsToUser(int userId, PaginationFilter filter)
          {
               var request = _entitites.Include(x => x.Post).ThenInclude(x => x.PostedBy)
                                        .Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Authors)
                                        .Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Categories)
                                        .Include(x => x.User)
                                        .Where(x => x.Post.PostedById == userId)
                                        .Where(x => x.Status == RequestStatus.Pending);

               var result = request.CreatePaginatedResponse<Request, RequestDto>(null, null, filter, _mapper);

               return result;
          }

          public PagedResponse<RequestDto> GetRequestFromUser(int userId, PaginationFilter filter)
          {
               var request = _entitites.Include(x => x.Post).ThenInclude(x => x.PostedBy)
                                        .Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Authors)
                                        .Include(x => x.Post).ThenInclude(x => x.Book).ThenInclude(x => x.Categories)
                                        .Include(x => x.User)
                                        .Where(x => x.UserId == userId)
                                        .Where(x => x.Status == RequestStatus.Pending);

               var result = request.CreatePaginatedResponse<Request, RequestDto>(null, null, filter, _mapper);

               return result;
          }

     }
}
