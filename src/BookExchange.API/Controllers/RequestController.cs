using AutoMapper;
using BookExchange.Application.Request.Commands;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
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
     public class RequestController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public RequestController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          [HttpPut("{id}")]
          public async Task<IActionResult> UpdateRequest(int id, [FromBody] UpdateRequestDto requestDto)
          {
               var command = _mapper.Map<UpdateRequestCommand>(requestDto);
               command.Id = id;

               var request = await _mediator.Send(command);

               var result = _mapper.Map<RequestDto>(request);
               return Ok(result);
          }
     }
}
