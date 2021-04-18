using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using BookExchange.Services;
using BookExchange.Domain.DTOs;
using BookExchange.Domain.Models;
using BookExchange.Infrastructure.Persistance;

namespace BookExchange.API
{
     public class Program
     {
          public static void Main(string[] args) {
               /*BookInfoService bookService = new BookInfoService();
               BookInfoDTO result = bookService.GetBookByISBN("9780393966473").Result;
               if (result == null) {
                    Console.WriteLine("Not found");
                    return;
               }

               //Console.WriteLine(result.Title);
               SeedDatabase();
               CreateHostBuilder(args).Build().Run();*/
               /*W
               var context = new BookExchangeDbContextFactory().CreateDbContext(new string[] { });
               var book1 = context.Books.First();
               //var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDto>());
               var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDto>());
               var mapper = new Mapper(config);

               var dto2 = mapper.Map<Book, BookDto>(book1);
               //BookDto dto = mapper.Map<BookDto>(book1);
               Console.WriteLine(dto2.Id + " " + dto2.Title + " " + dto2.ISBN);*/
               /*
               var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDto>());
               var mapper = config.CreateMapper();
               var dto = mapper.Map<BookDto>(book1.Select*/
               var q = nameof(string.Contains);
               Console.WriteLine(q);
               SeedDatabase();
              /* var context = new BookExchangeDbContextFactory().CreateDbContext(new string[] { });
               BookRepository bookRepository = new BookRepository(context);
               var book = bookRepository.GetByIdWithInclude(1, b => b.Details);

               var configuration = new MapperConfiguration(cfg => {
                    cfg.AddProfile<MappingProfile>();
               });

               var mapper = configuration.CreateMapper();
               BookDto dto = mapper.Map<BookDto>(book);
               */
               CreateHostBuilder(args).Build().Run();
          }

          public static void SeedDatabase()
          {
               using (var context = new BookExchangeDbContextFactory().CreateDbContext(new string[] { }))
               {
                    context.Database.EnsureCreated();

                    // create 3 users
                    if (!context.Users.Any())
                    {
                         context.Users.Add(new User { Username = "admin", FirstName = "Dima", LastName = "Trubca", Password = "secret" });
                         context.Users.Add(new User { Username = "tourist", FirstName = "Genady", LastName = "Korotkevichi", Password = "secret", Points = 1 });
                         context.Users.Add(new User { Username = "jiangly", FirstName = "Petru", LastName = "Mitrivich", Password = "secret", Points = 2 });
                    }
                    context.SaveChanges();

                    // create user contacts
                    if (!context.Set<UserContact>().Any())
                    {
                         context.Add(new UserContact { UserId = 1, Email = "admin@gmail.com" });
                         context.Add(new UserContact { UserId = 2, Email = "tourist313@gmail.com", Country="Moldova"});
                         context.Add(new UserContact { UserId = 3, Email = "jiangly323@gmail.com" , Country="Moldova", City="Chisinau"});
                    }

                    // create 3 books
                    if (!context.Books.Any())
                    {
                         context.Books.Add(new Book { ISBN = "9780786112517", Title = "War and Peace", ShortDescription= "War and Peace is a novel by the Russian author Leo Tolstoy..." });
                         context.Books.Add(new Book { ISBN = "9788807900501", Title = "A Confession", ShortDescription= "A Confession, or My Confession, is a short work on the subject of melancholia, philosophy and religion" });
                         context.Books.Add(new Book { ISBN = "9780786105236", Title = "The Cossacks", ShortDescription= "The Cossacks is a short novel by Leo Tolstoy, published in 1863 in the popular literary magazine The Russian Messenger" });
                         }
                    context.SaveChanges();

                    if (!context.Set<BookDetails>().Any())
                    {
                         context.Add(new BookDetails { BookId=1, Description="Long Description1 word", PageCount=300, Publisher="PublisherName" });
                         context.Add(new BookDetails { BookId=2, Description="Long Description2 test", PageCount=200, Publisher="PublisherName" });
                         context.Add(new BookDetails { BookId=3, Description="Long Description3 just", PageCount=150, Publisher="PublisherName" });
                    }

                    if (!context.Set<BookCategory>().Any())
                    {
                         context.Add(new BookCategory { Label= "Novel" });
                         context.Add(new BookCategory { Label= "Fiction" });
                         context.Add(new BookCategory { Label= "War story" });
                    }

                    if (!context.Set<Author>().Any())
                    {
                         context.Add(new Author { Name = "Leo Tolstoy" });
                         context.Add(new Author { Name = "Greg McKewn" });
                         context.Add(new Author { Name = "John Green" });
                    }
                    context.SaveChanges();

                    if (!context.Set<BookAuthor>().Any())
                    {
                         context.Add(new BookAuthor { BookId = 1, AuthorId = 1 });
                         context.Add(new BookAuthor { BookId = 2, AuthorId = 1 });
                         context.Add(new BookAuthor { BookId = 3, AuthorId = 1 });

                    }
                    context.SaveChanges();

                    if (!context.Set<BookBookCategory>().Any()) 
                    {
                         context.Add(new BookBookCategory { BookId=1, CategoryId=1});
                         context.Add(new BookBookCategory { BookId=1, CategoryId=2});
                         context.Add(new BookBookCategory { BookId=1, CategoryId=3});
                         context.Add(new BookBookCategory { BookId=2, CategoryId=2});
                         context.Add(new BookBookCategory { BookId=3, CategoryId=1});
                         context.Add(new BookBookCategory { BookId=3, CategoryId=2});
                    }


                    context.SaveChanges();

                    // add book conditions
                    if (!context.Set<Condition>().Any())
                    {
                         context.Add(new Condition { Label = "New", Description = "A brand-new copy with cover and original protective wrapping intact." });
                         context.Add(new Condition { Label = "Very Good", Description = "Item may have minor cosmetic defects (marks, wears, cuts, bends, crushes) on the cover, spine, pages or dust cover. Shrink wrap, dust covers, or boxed set case may be missing." });
                         context.Add(new Condition { Label = "Good", Description= "All pages and cover are intact (including the dust cover, if applicable). Spine may show signs of wear. Pages may include limited notes and highlighting." });
                         context.Add(new Condition { Label = "Acceptable", Description = "All pages and the cover are intact, but shrink wrap, dust covers, or boxed set case may be missing." });
                    };


                    if (!context.Posts.Any())
                    {
                         context.Posts.Add(new Post { PostedById=1, BookId=1, ConditionId=1, Type=PostType.Lend, MaxLendingPeriod=30 });
                         context.Posts.Add(new Post { PostedById=1, BookId=2, ConditionId=2, Type=PostType.Lend, MaxLendingPeriod=50 });
                         context.Posts.Add(new Post { PostedById=2, BookId=1, ConditionId=1, Type=PostType.Lend, MaxLendingPeriod=25 });

                         context.Posts.Add(new Post { PostedById=1, BookId=2, ConditionId=3, Type=PostType.GiveAway });
                         context.Posts.Add(new Post { PostedById=2, BookId=2, ConditionId=2, Type=PostType.GiveAway });
                         context.Posts.Add(new Post { PostedById=2, BookId=1, ConditionId=2, Type=PostType.GiveAway });
                    }

                    context.SaveChanges();

                    // populate wishlist table
                    if (!context.WishList.Any())
                    {
                         context.WishList.Add(new WishList { UserId=1, BookId=3 });
                         context.WishList.Add(new WishList { UserId=1, BookId=2 });
                         context.WishList.Add(new WishList { UserId=3, BookId=2 });
                         context.WishList.Add(new WishList { UserId=3, BookId=1 });
                    }

                    // populate requests table
                    if (!context.Requests.Any())
                    {
                         context.Requests.Add(new Request { PostId = 4, UserId = 1 });
                         context.Requests.Add(new Request { PostId = 5, UserId = 2 });
                         context.Requests.Add(new Request { PostId = 1, UserId = 3 });
                         context.Requests.Add(new Request { PostId = 2, UserId = 1 });
                    }
                    context.SaveChanges();

                    // populate bookmarks table
                    if (!context.Bookmarks.Any())
                    {
                         context.Bookmarks.Add(new Bookmark { UserId=1, PostId=4 });
                         context.Bookmarks.Add(new Bookmark { UserId=1, PostId=5 });
                         context.Bookmarks.Add(new Bookmark { UserId=2, PostId=5 });
                         context.Bookmarks.Add(new Bookmark { UserId=3, PostId=5 });
                    }

                    // populate book reviews
                    if (!context.Reviews.Any())
                    {
                         context.Reviews.Add(new BookReview { BookId=1, ReviewerId=1, Rating=5, Message="Very good book!" });
                         context.Reviews.Add(new BookReview { BookId=1, ReviewerId=2, Rating=4, Message="I did really like it." });
                         context.Reviews.Add(new BookReview { BookId=2, ReviewerId=2, Rating=3, Message="Not bad" });

                         context.Reviews.Add(new PostReview { PostId=1, ReviewerId=3, Rating=5, Message="Super" });
                         context.Reviews.Add(new PostReview { PostId=1, ReviewerId=2, Rating=4, Message="Very Good" });
                         context.Reviews.Add(new PostReview { PostId=2, ReviewerId=2, Rating=4, Message="Excelent" });
                         context.Reviews.Add(new PostReview { PostId=2, ReviewerId=1, Rating=3, Message="Good" });
                         context.Reviews.Add(new PostReview { PostId=3, ReviewerId=1, Rating=5, Message="Fantastic" });
                    }

                    context.SaveChanges();
               }
          }


          public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => {
                         webBuilder.UseStartup<Startup>();
                    })
                    .ConfigureLogging((hostingContext, logging) => {
                         logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                         logging.AddConsole();
                         logging.AddDebug();
                         logging.AddEventSourceLogger();
                    });
          

     }
}
