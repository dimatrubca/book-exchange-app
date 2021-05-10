using AutoMapper;
using BookExchange.Application.Common.Configurations;
using BookExchange.Application.Users.Commands;
using BookExchange.Application.Users.Queries;
using BookExchange.Domain.Auth;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
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
          private readonly UserManager<ApplicationUser> _userManager;

          public UserController(IMediator mediator, IMapper mapper, UserManager<ApplicationUser> userManager)
          {
               _mediator = mediator;
               _mapper = mapper;
               _userManager = userManager;
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

          
          [HttpGet("id")]
          [Authorize]
          public async Task<IActionResult> Get(int id)
          {
               Console.WriteLine(id);
               string myId = _userManager.GetUserId(HttpContext.User);
               var userID = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

               return Ok(new { Id = myId });
               //var user = await _mediator.Send(new GetUserQuery { Id = id });
               //var result = _mapper.Map<UserDto>(user);

               //return Ok(result);
          }
     }
};
