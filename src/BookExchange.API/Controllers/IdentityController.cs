using BookExchange.API.Identity;
using BookExchange.API.Identity.DTOs;
using BookExchange.Application.Common.Configurations;
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
using IdentityUser = BookExchange.API.Identity.IdentityUser;

namespace BookExchange.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [AllowAnonymous]
     public class IdentityController : ControllerBase
     {
          private readonly SignInManager<IdentityUser> _signInManager;

          public IdentityController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AuthOptions> authOptions)
          {
               _signInManager = signInManager;
               _userManager = userManager;
               _authenticationOptions = authOptions.Value;
          }

          private readonly UserManager<IdentityUser> _userManager;
          private readonly AuthOptions _authenticationOptions;

          [HttpGet]
          public IActionResult Get()
          {
               return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
          }

          [HttpPost("register")]
          public async Task<IActionResult> Register(RegisterIdentityUserDto userDto)
          {
               var user = new IdentityUser
               {
                    UserName = userDto.Username,
                    Email = userDto.Email,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName
               };

               var result = await _userManager.CreateAsync(user, userDto.Password);

               if (result.Succeeded) {
                    return Ok();
               }

               return BadRequest(result.Errors);
          }

          [HttpPost("login")]
          public async Task<IActionResult> Login(LoginIdentityUserDto userDto)
          { 
               var checkingPassword = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);

               if (!checkingPassword.Succeeded)
               {
                    return Unauthorized();
               }

               var signInCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
               var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _authenticationOptions.Issuer,
                    audience: _authenticationOptions.Audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signInCredentials
               );

               var tokenHandler = new JwtSecurityTokenHandler();
               var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

               return Ok(new { AccessToken = encodedToken});
          }
     }
}
