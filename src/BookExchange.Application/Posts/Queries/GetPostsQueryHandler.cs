using BookExchange.Domain;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Posts.Queries
{
     class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<Post>>
     {
          private readonly IPostRepository _postRepository;

          public GetPostsQueryHandler(IPostRepository postRepository)
          {
               _postRepository = postRepository;
          }

          public Task<List<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
          {
               Expression<Func<Post, bool>> predicate = (p => true);

               if (request.ConditionId != null)
                    predicate = predicate.AndAlso(p => p.ConditionId == request.ConditionId);

               if (request.PostedById != null)
                    predicate = predicate.AndAlso(p => p.PostedById == request.PostedById);

               if (request.Status != null)
                    predicate = predicate.AndAlso(p => p.Status == request.Status);

               var posts = _postRepository.GetAllByCondition(predicate);

               return Task.FromResult(posts);
          }
     }
}
