using AutoMapper;
using BookExchange.Application.Deals.Queries;
using BookExchange.Application.Request.Queries;
using BookExchange.Application.Users.Commands;
using BookExchange.Application.Users.Queries;
using BookExchange.Domain;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Filter;
using BookExchange.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookExchange.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [Authorize("ApiScope")]
     public class UserController : ControllerBase
     {

          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public UserController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          [HttpGet("current-user")]
          public async Task<IActionResult> GetCurrentUser()
          {
               var user = await _mediator.Send(new GetCurrentUserQuery());
               var result = _mapper.Map<UserDto>(user); 

               return Ok(result);
          }


          [HttpPost()]
          public async Task<IActionResult> CreateUser()
          {
               var user = await _mediator.Send(new CreateUserCommand());

               return Ok();
          }

          [HttpGet("id")]
          public async Task<IActionResult> GetUser(int id)
          {
               var user = await _mediator.Send(new GetUserQuery());
               var result = _mapper.Map<UserDto>(user);

               return Ok(result);
          }

          [HttpGet]
          public async Task<IActionResult> GetAllUsers()
          {
               var users = await _mediator.Send(new GetUsersQuery());
               var result = _mapper.Map<ICollection<UserDto>>(users); // TODO: check syntax

               return Ok(result);
          }


          [HttpDelete]
          public async Task<IActionResult> DeleteUser()
          {
               await _mediator.Send(new DeleteUserCommand());

               return NoContent();
          }



          [HttpGet("{id}/stats")]
          public async Task<IActionResult> GetUserStats(int id)
          {
               var response = await _mediator.Send(new GetUserStatsQuery { UserId = id });

               return Ok(response);
          }

          [HttpGet("leaderboard")]
          [AllowAnonymous]
          public async Task<IActionResult> GetTopUsers([FromQuery] GetLeaderboardDto dto)
          {
               var query = _mapper.Map<GetTopUsersQuery>(dto);
               var users = await _mediator.Send(query);

               var response = _mapper.Map<List<TopUserDto>>(users);

               return Ok(response);
          }


          [HttpGet("{id}/books/recommended")]
          [AllowAnonymous]
          public async Task<IActionResult> GetRecommendedBooks(int id, [FromQuery] int topN = 3)
          {
               var books = await _mediator.Send(new GetRecommendedBooksQuery { Id = id, TopN = topN });

               var response = _mapper.Map<List<BookDto>>(books);

               return Ok(response);
          }


          [HttpGet("{id}/books/wished")]
          public async Task<IActionResult> GetWishedBooks(int id, [FromQuery] BooksFilter filter)
          {
               var query = _mapper.Map<GetUserWishedBooksQuery>(filter);
               query.UserId = id;
               var response = await _mediator.Send(query);

               return Ok(response);
          }

          [HttpPost("{id}/books/wished")]
          public async Task<IActionResult> AddBookToWishlist(int id, [FromBody] WishListDto wishlistDto)
          {
               var response = await _mediator.Send(new AddToWishlistCommand { UserId = id, BookId = wishlistDto.BookId });

               return Ok(response);
          }


          [HttpGet("{id}/posts/owned")]
          [AllowAnonymous]
          public async Task<IActionResult> GetUserActivePosts(int id, [FromQuery] PaginationFilter filter)
          {
               var query = _mapper.Map<GetUserPostsQuery>(filter);
               query.UserId = id;

               var response = await _mediator.Send(query);

               return Ok(response);
          }


          [HttpPost("{id}/requests/")]
          [AllowAnonymous]
          public async Task<IActionResult> RequestPost(int id, [FromBody] CreateRequestDto requestDto)
          {
              var result = await _mediator.Send(new RequestPostCommand { UserId = id, PostId = requestDto.PostId});

               return Ok(result);
          }


          [HttpGet("{id}/requests/to")]
          [AllowAnonymous]
          public async Task<IActionResult> GetRequestsToUser(int id, [FromQuery] PaginationFilter filter)
          {
               var query = _mapper.Map<GetRequestsToUserQuery>(filter);
               query.UserId = id;
               var result = await _mediator.Send(query);

               return Ok(result);
          }

          [HttpGet("{id}/requests/from")]
          [AllowAnonymous]
          public async Task<IActionResult> GetRequestsFromUser(int id, [FromQuery] PaginationFilter filter)
          {
               var query = _mapper.Map<GetRequestsFromUserQuery>(filter);
               query.UserId = id;
               var result = await _mediator.Send(query);

               return Ok(result);
          }

          [HttpGet("{id}/deals/from")]
          [AllowAnonymous]
          public async Task<IActionResult> GetDealsFromUser(int id, [FromQuery] PaginationFilter filter)
          {
               var query = _mapper.Map<GetDealsFromUserQuery>(filter);
               query.UserId = id;

               var response = await _mediator.Send(query);

               return Ok(response);
          }

          [HttpGet("{id}/deals/to")]
          [AllowAnonymous]
          public async Task<IActionResult> GetDealsToUser(int id, [FromQuery] PaginationFilter filter)
          {
               var query = _mapper.Map<GetDealsToUserQuery>(filter);
               query.UserId = id;

               var response = await _mediator.Send(query);

               return Ok(response);
          }
     }
}
