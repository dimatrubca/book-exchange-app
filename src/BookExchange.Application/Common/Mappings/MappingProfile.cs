using AutoMapper;
using BookExchange.Application.Books.Commands;
using BookExchange.Application.Posts.Commands;
using BookExchange.Application.Users.Commands;
using BookExchange.Domain.Auth;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Application.Common.Mappings
{
     public class MappingProfile : Profile
     {
          public MappingProfile()
          {
               CreateMap<Book, BookDto>();
               CreateMap<CreateBookCommand, Book>();
               CreateMap<BookDetails, BookDetailsDto>();

               CreateMap<Post, PostDto>();
               CreateMap<PostDto, Post>();
               CreateMap<CreatePostCommand, Post>();
               CreateMap<ReplacePostCommand, Post>();

               CreateMap<CreateUserCommand, ApplicationUser>();
               CreateMap<ApplicationUser, UserDto>();
          }
     }
}
