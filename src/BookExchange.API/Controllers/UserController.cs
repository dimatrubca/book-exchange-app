using AutoMapper;
using BookExchange.Application.Common.Configurations;
using BookExchange.Application.Users.Commands;
using BookExchange.Application.Users.Queries;
using BookExchange.Domain.Auth;
using BookExchange.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookExchange.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class UserController : ControllerBase
     {

          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public UserController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          [AllowAnonymous]
          [HttpPost("login")]
          public async Task<IActionResult> Login(LogginUserCommand command)
          {
               var encodedToken = await _mediator.Send(command);

               if (encodedToken == null) {
                    return Unauthorized();
               }
               return Ok(new { AccessToken = encodedToken });
          }

          [AllowAnonymous]
          [HttpPost("register")]
          public async Task<ActionResult> Register(CreateUserCommand command)
          {
               var user = await _mediator.Send(command);

               return Ok();
          }

          /*
          [HttpGet("id")]
          public async Task<IActionResult> Get(int id)
          {
               var user = await _mediator.Send(new GetUserQuery { Id = id });
               var result = _mapper.Map<UserDto>(user);

               return Ok(result);
          }*/
     }
};
