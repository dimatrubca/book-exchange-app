//using AutoMapper;
//using BookExchange.Application.Common;
//using BookExchange.Application.Common.Exceptions;
//using BookExchange.Domain.DTOs;
//using BookExchange.Domain.Filter;
//using BookExchange.Domain.Interfaces;
//using BookExchange.Domain.Models;
//using BookExchange.Domain.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BookExchange.Application.Users.Queries
//{
//     public class GetUserRequestedPostsQueryHandler : PaginatedRequestHandler<GetUserRequestedPostsQuery, PostDto>
//     {
//          private readonly IRequestRepository _requestRepository;
//          private readonly IUserRepository _userRepository;
//          private readonly IMapper _mapper;

//          public GetUserRequestedPostsQueryHandler(IRequestRepository requestRepository, IUserRepository userRepository, IMapper mapper)
//          {
//               _requestRepository = requestRepository;
//               _userRepository = userRepository;
//               _mapper = mapper;
//          }

//          public override Task<PagedResponse<PostDto>> Handle(GetUserRequestedPostsQuery request, CancellationToken cancellationToken)
//          {
//               if (_userRepository.GetById(request.UserId) == null)
//               {
//                    throw new NotFoundException(nameof(User), request.UserId);
//               }

//               PaginationFilter filter = new PaginationFilter
//               {
//                    PageNumber = 1,
//                    PageSize = 10
//               };

//               var result = _requestRepository.GetRequestedPosts(request.UserId, filter, _mapper);


//               return Task.FromResult(result);
//          }
//     }
//}
