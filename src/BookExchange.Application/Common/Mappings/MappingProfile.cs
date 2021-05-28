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
using BookExchange.Application.Users.Queries;
using BookExchange.Application.Request.Commands;
using BookExchange.Application.Deals.Commands;
using BookExchange.Application.Deals.Queries;
using BookExchange.Application.Request.Queries;
using BookExchange.Domain.ReadModel;

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

               CreateMap<BooksFilter, GetUserWishedBooksQuery>();
               CreateMap<GetUserWishedBooksQuery, PaginationFilter>();

               CreateMap<PostsFilter, GetPostsQuery>();
               CreateMap<GetPostsQuery, PaginationFilter>();


               CreateMap<CreateAuthorDto, CreateAuthorCommand>();
               CreateMap<Author, AuthorDto>();

               CreateMap<Category, CategoryDto>();

               CreateMap<BookCreatedEvent, ReadModelBook>();

               CreateMap<Wishlist, WishListDto>();

               CreateMap<WishlistFilter, GetWishListAllQuery>();
               CreateMap<WishlistFilter, GetUserWishlistQuery>();
               CreateMap<GetWishListAllQuery, PaginationFilter>();
               CreateMap<GetUserWishlistQuery, PaginationFilter>();

               //CreateMap<Dea
               CreateMap<UpdateRequestDto, UpdateRequestCommand>();
               CreateMap<Domain.Models.Request, RequestDto>();

               CreateMap<UpdateDealDto, UpdateDealCommand>();
               CreateMap<Deal, DealDto>();

               CreateMap<PaginationFilter, GetDealsFromUserQuery>();
               CreateMap<PaginationFilter, GetDealsToUserQuery>();

               CreateMap<GetDealsFromUserQuery, PaginationFilter>();
               CreateMap<GetDealsToUserQuery, PaginationFilter>();

               CreateMap<GetRequestsToUserQuery, PaginationFilter>();
               CreateMap<GetRequestsFromUserQuery, PaginationFilter>();

               CreateMap<PaginationFilter, GetRequestsToUserQuery>();
               CreateMap<PaginationFilter, GetRequestsFromUserQuery>();

               CreateMap<GetUserPostsQuery, PaginationFilter>();
               CreateMap<PaginationFilter, GetUserPostsQuery>();

               CreateMap<User, TopUserDto>();
               CreateMap<GetLeaderboardDto, GetTopUsersQuery>();
          }
     }
}
