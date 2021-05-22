using AutoMapper;
using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using BookExchange.Domain.Wrappers;
using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.WishList.Queries
{
     using WishList = BookExchange.Domain.Models.WishList;

     public class GetUserWishlistQueryHandler : IRequestHandler<GetUserWishlistQuery, PagedResponse<WishListDto>>
     {
          private readonly IRepositoryBase<WishList> wishlistRepository;
          private readonly IHttpContextAccessor _contextAccessor;
          private readonly IUserRepository _userRepository;
          private readonly IMapper _mapper;

          public Task<PagedResponse<WishListDto>> Handle(GetUserWishlistQuery request, CancellationToken cancellationToken)
          {
               string identityId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Id)?.Value;

               /*if (identityId == null)
               {
                    throw new UnauthorizedException("");
               }*/

               User user = _userRepository.GetUserByIdentityId(identityId);

               var predicates = new List<Expression<Func<WishList, bool>>>() {
                    w => w.UserId == user.Id
               };

               var paginationRequestFilter = _mapper.Map<PaginationFilter>(request);

               var result = wishlistRepository.GetPagedData<WishListDto>(predicates, null, paginationRequestFilter, _mapper);

               return Task.FromResult(result);
          }
     }
}
