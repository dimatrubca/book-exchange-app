using AutoMapper;
using BookExchange.Application.Books.Commands;
using BookExchange.Domain.Commands;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
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
          public async Task<IActionResult> GetById(int id, bool includeDetails) {
               var book = await _mediator.Send(new GetBookQuery { Id=id, IncludeDetails=includeDetails });

               if (book == null) {
                    return NotFound();
               }

               var bookDto = _mapper.Map<BookDto>(book);

               return Ok(bookDto);
          } 


          [HttpGet]
          public async Task<IActionResult> GetAll([FromQuery] GetBooksQuery query) {
               List<Book> books = await _mediator.Send(query);

               var result = books.Select(b => _mapper.Map<BookDto>(b));

               return Ok(result);
          }

          [HttpPost]
          public async Task<IActionResult> Post([FromBody] CreateBookCommand command) {
               var book = await _mediator.Send(command);

               if (book == null)
                    return BadRequest("Book with such ISBN already exists");

               var result = _mapper.Map<Book>(book);

               return CreatedAtAction(nameof(GetById), new { id = book.Id }, result);
          }


          [HttpPatch("{id}")]
          public async Task<IActionResult> Patch(int id, [FromBody] UpdateBookCommand command) {
               if (id != command.Id) 
               {
                    BadRequest();
               }

               var book = await _mediator.Send(command);
               var result = _mapper.Map<Book>(book);

               return Ok(result);
          }

          [HttpPut("{id}")]
          public async Task<IActionResult> Put(int id, [FromBody] UpdateBookCommand command)
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
               bool isDeleted = await _mediator.Send(new DeleteBookByIdCommand { Id = id });

               return NoContent();
          }
     }
}
