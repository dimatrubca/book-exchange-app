using AutoMapper;
using BookExchange.Application.Books.Commands;
using BookExchange.Domain.Filter;
using BookExchange.Application.Posts.Commands;
using BookExchange.Application.Users.Commands;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using BookExchange.Application.Posts.Queries;
using BookExchange.Application.Authors.Commands;
using BookExchange.Application.Books.Events;
using BookExchange.Application.WishList.Queries;

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

               CreateMap<User, UserDto>();
               CreateMap<UserContact, UserContactDto>();


               CreateMap<BooksFilter, GetBooksQuery>();
               CreateMap<GetBooksQuery, PaginationFilter>();

               CreateMap<PostsFilter, GetPostsQuery>();
               CreateMap<GetPostsQuery, PaginationFilter>();

               CreateMap<Condition, ConditionDto>();

               CreateMap<CreateAuthorDto, CreateAuthorCommand>();
               CreateMap<Author, AuthorDto>();

               CreateMap<Category, CategoryDto>();

               CreateMap<BookCreatedEvent, ElasticBook>();

               CreateMap<WishListFilter, GetWishListAllQuery>();
               CreateMap<GetWishListAllQuery, PaginationFilter>();
          }
     }
}
