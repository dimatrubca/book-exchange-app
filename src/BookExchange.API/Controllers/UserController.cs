using AutoMapper;
using BookExchange.Application.Users.Commands;
using BookExchange.Application.Users.Queries;
using BookExchange.Domain.Auth;
using BookExchange.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class UserController : ControllerBase
     {
          private readonly SignInManager<ApplicationUser> _signInManager;
          private readonly UserManager<IdentityUser> _userManager;

          public UserController(SignInManager<ApplicationUser> signInManager)
          {
               _signInManager = signInManager;
          }

          [HttpPost]
          [Route("register")]
          public async Task<ActionResult> Register(RegisterUserDto registerUser)
          {
               var user = new ApplicationUser
               {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    EmailConfirmed = true
               };

               var result = await _userManager.CreateAsync(user, registerUser.Password);

               if (result.Succeeded)
               { 
                    var refreshUser = _context.UserRefreshTokens.S
               }
          }



          /*
          [HttpPost("")]
          public async Task<IActionResult> RegisterAsync(CreateUserCommand command)
          {
               var user = await _mediator.Send(command);
               var result = _mapper.Map<UserDto>(user);

               return Ok(result);
          }*/
          /*
          [HttpGet("")]
          public async Task<IActionResult Get(GetUserQuery query)
          {
               var getUserQuery = await _mediator.Send(query);
               var result = _mapper.Map<UserDto>(UserDto);

               return Ok(result);
          }*/

      /*    [HttpPost("/login")]
          public async Task<IActionResult Post(LoginUserCommand command) {
               var user = await _mediator.Send(command);
               var result = _mapper.Map<UserLoginDto>(user);

               return Ok(result);
          }

     */
     }
};
