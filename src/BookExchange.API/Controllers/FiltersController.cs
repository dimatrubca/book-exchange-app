using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class FiltersController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public FiltersController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }
          /*
          [HttpGet(']
          public async Task<IActionResult> Get(int id, bool includeDetails)
          {
               var book = await _mediator.Send(new GetBookQuery { Id = id, IncludeDetails = includeDetails });
               var bookDto = _mapper.Map<BookDto>(book);

               return Ok(new Response<BookDto>(bookDto));
          }*/
     }
}
