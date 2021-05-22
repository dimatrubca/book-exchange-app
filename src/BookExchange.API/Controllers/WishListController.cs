using AutoMapper;
using BookExchange.Application.WishList.Queries;
using BookExchange.Domain.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class WishListController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          [Authorize]
          [HttpGet]
          public async Task<IActionResult> GetUserWishlist()
          {
               var result = await _mediator.Send(new GetUserWishlistQuery());

               return Ok(result);
          }
          /*
          public async Task<IActionResult> GetAll([FromQuery] WishListFilter filter)
          {
               GetWishListAllQuery query = _mapper.Map<GetWishListAllQuery>(filter);
               var result = await _mediator.Send(query);

               return Ok(result);
          }*/
     }
}
