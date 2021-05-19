using BookExchange.API.Identity;
using BookExchange.API.Identity.DTOs;
using BookExchange.Application.Common.Configurations;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
     //[Authorize(AuthenticationSchemes = "Bearer")]
     // [Authorize]
     [Authorize(IdentityServerConstants.LocalApi.PolicyName)]

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

          /////////////////////////////// test routes
          [Authorize(Roles = "user")]
          [HttpGet("user")]
          public IActionResult GetBasic() {
               return Ok(new { Role=  "Basic" });
          }

          [Authorize(Roles = "admin")]
          [HttpGet("admin")]
          public IActionResult GetAdmin()
          {
               return Ok(new { Role = "admin" });
          }


          [HttpPost("register")]
          [AllowAnonymous]
          public async Task<IActionResult> Register([FromBody] RegisterIdentityUserDto userDto)
          {
               var user = new IdentityUser
               {
                    UserName = userDto.Username,
                    Email = userDto.Email
               };

               var result = await _userManager.CreateAsync(user, userDto.Password);

               if (result.Succeeded) {
                    return Ok();
               }

               return BadRequest(result.Errors);
          }

     }
}
