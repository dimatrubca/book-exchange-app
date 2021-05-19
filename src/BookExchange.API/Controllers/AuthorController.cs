using AutoMapper;
using BookExchange.Application.Authors.Commands;
using BookExchange.Application.Authors.Queries;
using BookExchange.Domain.DTOs;
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
     [AllowAnonymous]
     public class AuthorController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public AuthorController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll()
          {
               var author = await _mediator.Send(new GetAuthorsQuery());
               var result = _mapper.Map<List<AuthorDto>>(author);

               return Ok(result);
          }

          [HttpPost]
          public async Task<IActionResult> Post([FromBody] CreateAuthorDto authorDto)
          {
               var command = _mapper.Map<CreateAuthorCommand>(authorDto); // todo: create profile
               var author = await _mediator.Send(command);

               var result = _mapper.Map<AuthorDto>(author);

               return Ok(result);
          }

          [HttpDelete("id")]
          public async Task<IActionResult> Delete(int id)
          {
               var result = await _mediator.Send(new DeleteAuthorCommand { Id = id });
               return NoContent();
          }
     }
}
