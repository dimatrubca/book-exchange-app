using BookExchange.IdentityServer.DTOs;
using BookExchange.IdentityServer.Models;
using IdentityServer4;
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

namespace BookExchange.IdentityServer.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class IdentityController : ControllerBase
     {

          public IdentityController(UserManager<ApplicationIdentityUser> userManager)
          {
               _userManager = userManager;
          }

          private readonly UserManager<ApplicationIdentityUser> _userManager;

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
               var user = new ApplicationIdentityUser
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
