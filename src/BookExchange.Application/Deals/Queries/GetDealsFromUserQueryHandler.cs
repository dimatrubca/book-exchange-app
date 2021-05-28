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

namespace BookExchange.Application.Deals.Queries
{
     public class GetDealsFromUserQueryHandler : PaginatedRequestHandler<GetDealsFromUserQuery, DealDto>
     {
          private readonly IUserRepository _userRepository;
          private readonly IDealRepository _dealsRepository;
          private readonly IMapper _mapper;

          public GetDealsFromUserQueryHandler(IDealRepository dealsRepository, IMapper mapper, IUserRepository userRepository)
          {
               _dealsRepository = dealsRepository;
               _mapper = mapper;
               _userRepository = userRepository;
          }

          public override Task<PagedResponse<DealDto>> Handle(GetDealsFromUserQuery request, CancellationToken cancellationToken)
          {
               if (_userRepository.GetById(request.UserId) == null)
               {
                    throw new NotFoundException(nameof(User), request.UserId);
               }

               var filter = _mapper.Map<PaginationFilter>(request);

               var result = _dealsRepository.GetDealsFromUser(request.UserId, filter);

               return Task.FromResult(result);
          }
     }
}
