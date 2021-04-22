using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Posts.Commands
{
     class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Post>
     {
          private readonly IPostRepository _postRepository;

          public UpdatePostCommandHandler(IPostRepository postRepository)
          {
               _postRepository = postRepository;
          }

          public Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
          {
               var post = _postRepository.GetById(request.Id);

               if (post == null)
               {
                    throw new NotFoundException(nameof(Post), request.Id);
               }

               if (request.ConditionId != null)
                    post.ConditionId = request.ConditionId;

               if (request.Status.HasValue)
                    post.Status = request.Status.Value;

               _postRepository.SaveAll();

               return Task.FromResult(post);
          }
     }
}
