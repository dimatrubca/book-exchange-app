using AutoMapper;
using BookExchange.Domain;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Posts.Queries
{
     class GetPostsQueryHandler :  IRequestHandler<GetPostsQuery, PagedResponse<List<PostDto>>>
     {
          private readonly IPostRepository _postRepository;
          private readonly IMapper _mapper;

          public GetPostsQueryHandler(IPostRepository postRepository, IMapper mapper)
          {
               _postRepository = postRepository;
               _mapper = mapper;
          }

          public Task<PagedResponse<List<PostDto>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
          {
               var includes = new List<Expression<Func<Post, Object>>>();
               var predicates = new List<Expression<Func<Post, bool>>>();

               if (request.IncludeBook)
                    includes.Add(p => p.Book);

               if (request.IncludeCondition)
                    includes.Add(p => p.Condition);

               if (request.IncludePostedBy)
                    includes.Add(p => p.PostedBy);

               if (request.ConditionId != null)
                    predicates.Add(p => p.ConditionId == request.ConditionId);

               if (request.PostedById != null)
                    predicates.Add(p => p.PostedById == request.PostedById);

               if (request.Status != null)
                    predicates.Add(p => p.Status.ToString() == request.Status);

               if (request.BookId != null)
                    predicates.Add(p => p.BookId == request.BookId);

               var paginationRequestFilter = _mapper.Map<PaginationRequestFilter>(request);

               var posts = _postRepository.GetPagedData<PostDto>(predicates, includes, paginationRequestFilter, _mapper);

               return Task.FromResult(posts);
          }
     }
}
