using AutoMapper;
using BookExchange.Application.Categories.Commands;
using BookExchange.Application.Categories.Queries;
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
     public class CategoryController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public CategoryController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll() {
               var categories = await _mediator.Send(new GetCategoriesQuery());

               var result = _mapper.Map<List<CategoryDto>>(categories);

               return Ok(result);
          }

          [HttpPost]
          public async Task<IActionResult> Post([FromBody] string categoryName) {
               var category = await _mediator.Send(new CreateCategoryCommand { Label = categoryName });

               var result = _mapper.Map<CategoryDto>(category);

               return Ok(result);
          }

          [HttpDelete("id")]
          public async Task<IActionResult> Delete(int id)
          {
               var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });
               return NoContent();
          }

     }
}
