using AutoMapper;
using BookExchange.Application.Common;
using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Request.Queries
{
     public class GetRequestsFromUserQueryHandler : PaginatedRequestHandler<GetRequestsFromUserQuery, RequestDto>
     {
          private readonly IUserRepository _userRepository;
          private readonly IRequestRepository _requestRepository;
          private readonly IMapper _mapper;

          public GetRequestsFromUserQueryHandler(IMapper mapper, IUserRepository userRepository, IRequestRepository requestRepository)
          {
               _mapper = mapper;
               _userRepository = userRepository;
               _requestRepository = requestRepository;
          }

          public override Task<PagedResponse<RequestDto>> Handle(GetRequestsFromUserQuery query, CancellationToken cancellationToken)
          {
               if (_userRepository.GetById(query.UserId) == null)
               {
                    throw new NotFoundException(nameof(User), query.UserId);
               }

               var filter = _mapper.Map < PaginationFilter > (query);
               var result = _requestRepository.GetRequestFromUser(query.UserId, filter);
               return Task.FromResult(result);
          }
     }
}
