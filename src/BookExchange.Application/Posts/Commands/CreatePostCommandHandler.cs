using BookExchange.Domain.Models;
using BookExchange.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace BookExchange.Application.Posts.Commands
{
     class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
     {
          private readonly IMapper _mapper;
          private readonly IPostRepository _postRepository;

          public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
          {
               _postRepository = postRepository;
               _mapper = mapper;
          }

          public Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
          {
               var post = _mapper.Map<Post>(request);
               /*var post = new Post
               {
                    BookId = request.BookId,
                    PostedById = request.PostedById,
                    ConditionId = request.ConditionId
               };*/

               _postRepository.Add(post);
               _postRepository.SaveAll();

               return Task.FromResult(post);
          }
     }
}
