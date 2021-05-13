using AutoMapper;
using BookExchange.Application.Books.Commands;
using BookExchange.Application.Common.Exceptions;
using BookExchange.Domain.Commands;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
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
     [Authorize]
     public class BookController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public BookController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          [HttpGet("{id}")]
          [AllowAnonymous]
          public async Task<IActionResult> Get(int id, bool includeDetails) {
               var book = await _mediator.Send(new GetBookQuery { Id=id, IncludeDetails=includeDetails });
               var bookDto = _mapper.Map<BookDto>(book);
              
               return Ok(bookDto);
          } 


          [HttpGet]
          [Authorize]
          public async Task<IActionResult> GetAll([FromQuery] GetBooksQuery query) {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           List<Book> books = await _mediator.Send(query);
               var result = books.Select(b => _mapper.Map<BookDto>(b));

               return Ok(result);                
          }

          [HttpPost]
          public async Task<IActionResult> Post([FromForm] CreateBookCommand command) {
               var book = await _mediator.Send(command);
               var result = _mapper.Map<BookDto>(book);

               return CreatedAtAction(nameof(Get), new { id = book.Id }, result);
          }


          [HttpPatch("{id}")]
          public async Task<IActionResult> Patch(int id, [FromBody] UpdateBookCommand command) {
               if (id != command.Id) 
               {
                    BadRequest();
               }

               var book = await _mediator.Send(command);
               var result = _mapper.Map<BookDto>(book);

               return Ok(result);
          }

          [HttpPut("{id}")]
          public async Task<IActionResult> Put(int id, [FromBody] ReplaceBookCommand command)
          {
               if (id != command.Id)
               {
                    BadRequest();
               }

               var book = await _mediator.Send(command);

               return NoContent();
          }


          [HttpDelete("{id}")]
          public async Task<IActionResult> Delete(int id)
          {
               await _mediator.Send(new DeleteBookByIdCommand { Id = id });
               return NoContent();
          }
     }
}
