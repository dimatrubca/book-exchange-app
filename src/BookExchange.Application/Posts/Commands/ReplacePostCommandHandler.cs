using AutoMapper;
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
     class ReplacePostCommandHandler : IRequestHandler<ReplacePostCommand, Post>
     {
          private readonly IPostRepository _postRepository;
          private readonly IMapper _mapper;

          public ReplacePostCommandHandler(IPostRepository postRepository, IMapper mapper)
          {
               _postRepository = postRepository;
               _mapper = mapper;
          }

          public Task<Post> Handle(ReplacePostCommand request, CancellationToken cancellationToken)
          {
               var post = _postRepository.GetById(request.Id);

               if (post != null)
               {
                    _postRepository.Delete(post.Id);
               }

               _postRepository.SaveAll();
               post = _mapper.Map<Post>(request);
               _postRepository.Add(post);
               _postRepository.SaveAllWithIdentityInsert();

               return Task.FromResult(post);
          }
     }
}
