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
     class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
     {
          private readonly IPostRepository _postRepository;
          public DeletePostCommandHandler(IPostRepository postRepository)
          {
               _postRepository = postRepository;
          }

          public Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
          {
               var post = _postRepository.Delete(request.Id);

               if (post == null)
               {
                    throw new NotFoundException(nameof(Post), request.Id);
               }
               _postRepository.SaveAll();
               return Task.FromResult(Unit.Value);
          }
     }
}
