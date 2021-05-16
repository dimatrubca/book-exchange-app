using AutoMapper;
using BookExchange.Application.Books.Commands;
using BookExchange.Domain.Filter;
using BookExchange.Application.Posts.Commands;
using BookExchange.Application.Users.Commands;
using BookExchange.Domain.Auth;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using BookExchange.Application.Posts.Queries;

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
               CreateMap<User, UserDto>();
               CreateMap<UserContact, UserContactDto>();

               CreateMap<ApplicationUser, CreateUserCommand>();

               CreateMap<BookFilter, GetBooksQuery>();
               CreateMap<GetBooksQuery, PaginationRequestFilter>();

               CreateMap<PostFilter, GetPostsQuery>();
               CreateMap<GetPostsQuery, PaginationRequestFilter>();
          }
     }
}
