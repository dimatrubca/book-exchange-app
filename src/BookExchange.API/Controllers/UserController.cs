using AutoMapper;
using BookExchange.Application.Common.Configurations;
using BookExchange.Application.Users.Commands;
using BookExchange.Application.Users.Queries;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using IdentityServer4;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
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
               var result = _mapper.Map<UserDto>(user); // TODO: check user dto

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
          
         /* [HttpGet("id1")]
          [Authorize]
          public async Task<IActionResult> Get(int id)*/
          //{
              /* Console.WriteLine(id);
               string myId = _userManager.GetUserId(HttpContext.User);
               var userID = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

               return Ok(new { Id = myId });*/
               //var user = await _mediator.Send(new GetUserQuery { Id = id });
               //var result = _mapper.Map<UserDto>(user);

               //return Ok(result);
          /*}*/
     }
};
