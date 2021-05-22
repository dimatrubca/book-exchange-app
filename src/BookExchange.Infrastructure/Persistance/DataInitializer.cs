using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance
{
     public static class DataInitializer
     {
          public static void SeedDatabase()
          {
               using (var context = new BookExchangeDbContextFactory().CreateDbContext(new string[] { }))
               {
                    context.Database.EnsureCreated();

                    // create 3 books
                    if (!context.Books.Any())
                    {
                         context.Books.Add(new Book {
                              ISBN = "9780786112517",
                              Title = "War and Peace",
                              ShortDescription = "War and Peace is a novel by the Russian author Leo Tolstoy...",
                              Details = new BookDetails { Description = "Long Description1 word", PageCount = 300, Publisher = "PublisherName" },
                         });
                         context.Books.Add(new Book {
                              ISBN = "9788807900501",
                              Title = "A Confession",
                              ShortDescription = "A Confession, or My Confession, is a short work on the subject of melancholia, philosophy and religion" ,
                              Details = new BookDetails { Description = "Long Description2 test", PageCount = 200, Publisher = "PublisherName" },
                         });
                         context.Books.Add(new Book { 
                              ISBN = "9780786105236", 
                              Title = "The Cossacks", 
                              ShortDescription = "The Cossacks is a short novel by Leo Tolstoy, published in 1863 in the popular literary magazine The Russian Messenger",
                              Details = new BookDetails { BookId = 3, Description = "Long Description3 just", PageCount = 150, Publisher = "PublisherName" },
                         });
                    }
                    context.SaveChanges();


                    if (!context.Set<Category>().Any())
                    {
                         context.Add(new Category { Label = "Novel" });
                         context.Add(new Category { Label = "Fiction" });
                         context.Add(new Category { Label = "War story" });
                    }

                    if (!context.Set<Author>().Any())
                    {
                         context.Authors.Add(new Author { Name = "Leo Tolstoy" });
                         context.Authors.Add(new Author { Name = "Greg McKewn" });
                         context.Authors.Add(new Author { Name = "John Green" });
                    }

                    context.SaveChanges();

                    if (!context.Set<BookAuthor>().Any())
                    {
                         context.Add(new BookAuthor { BookId = 1, AuthorId = 1 });
                         context.Add(new BookAuthor { BookId = 2, AuthorId = 1 });
                         context.Add(new BookAuthor { BookId = 3, AuthorId = 1 });

                    }

                    if (!context.Set<BookCategory>().Any())
                    {
                         context.Add(new BookCategory { BookId = 1, CategoryId = 1 });
                         context.Add(new BookCategory { BookId = 1, CategoryId = 2 });
                         context.Add(new BookCategory { BookId = 1, CategoryId = 3 });
                         context.Add(new BookCategory { BookId = 2, CategoryId = 2 });
                         context.Add(new BookCategory { BookId = 3, CategoryId = 1 });
                         context.Add(new BookCategory { BookId = 3, CategoryId = 2 });
                    }



                    // add book conditions
                    if (!context.Set<Condition>().Any())
                    {
                         context.Add(new Condition { Label = "New", Description = "A brand-new copy with cover and original protective wrapping intact." });
                         context.Add(new Condition { Label = "Very Good", Description = "Item may have minor cosmetic defects (marks, wears, cuts, bends, crushes) on the cover, spine, pages or dust cover. Shrink wrap, dust covers, or boxed set case may be missing." });
                         context.Add(new Condition { Label = "Good", Description = "All pages and cover are intact (including the dust cover, if applicable). Spine may show signs of wear. Pages may include limited notes and highlighting." });
                         context.Add(new Condition { Label = "Acceptable", Description = "All pages and the cover are intact, but shrink wrap, dust covers, or boxed set case may be missing." });
                    };


                    // create 3 users
                    if (!context.Users.Any())
                    {
                         var user1 = new User
                         {
                              Username = "dimatrubca",
                              FirstName = "Dima",
                              LastName = "Trubca",
                              Points = 10,
                              IdentityId = "1",
                              UserContact = new UserContact { Email = "dimatrubca@gmail.com" },
                              Posts = new List<Post>()
                              {
                                   new Post { BookId = 1, ConditionId = 1 },
                                   new Post { BookId = 2, ConditionId = 2 }
                              }
                         };


                         var user2 = new User
                         {
                              Username = "valentin",
                              FirstName = "Valentin",
                              LastName = "Korotkevichi",
                              Points = 5,
                              IdentityId = "2",
                              UserContact = new UserContact { Email = "dimatrubca@outlook.com" },
                              Posts = new List<Post>()
                              {
                                   new Post { BookId = 1, ConditionId = 2 },
                                   new Post { BookId = 2, ConditionId = 3 }
                              }
                         };

                         context.Users.Add(user1);
                         context.Users.Add(user2);
                    }

                    context.SaveChanges();


                    // populate wishlist table
                    if (!context.Wishlist.Any())
                    {
                         context.Wishlist.Add(new Wishlist { UserId = 1, BookId = 3 });
                         context.Wishlist.Add(new Wishlist { UserId = 1, BookId = 2 });
                         context.Wishlist.Add(new Wishlist { UserId = 1, BookId = 1 });
                         context.Wishlist.Add(new Wishlist { UserId = 2, BookId = 2 });
                         context.Wishlist.Add(new Wishlist { UserId = 2, BookId = 1 });
                    }

                    // populate requests table
                    if (!context.Requests.Any())
                    {
                         context.Requests.Add(new Request { PostId = 3, UserId = 1 });
                         context.Requests.Add(new Request { PostId = 1, UserId = 2 });
                         context.Requests.Add(new Request { PostId = 2, UserId = 2 });
                    }


                    // populate bookmarks table
                    if (!context.Bookmarks.Any())
                    {
                         context.Bookmarks.Add(new Bookmark { UserId = 1, PostId = 4 });
                         context.Bookmarks.Add(new Bookmark { UserId = 1, PostId = 3 });
                         context.Bookmarks.Add(new Bookmark { UserId = 2, PostId = 2 });
                    }

                    // populate book reviews
                    if (!context.Reviews.Any())
                    {
                         context.Reviews.Add(new BookReview { BookId = 1, ReviewerId = 1, Rating = 5, Message = "Very good book!" });
                         context.Reviews.Add(new BookReview { BookId = 1, ReviewerId = 2, Rating = 4, Message = "I did really like it." });
                         context.Reviews.Add(new BookReview { BookId = 2, ReviewerId = 2, Rating = 3, Message = "Not bad" });

                         context.Reviews.Add(new PostReview { PostId = 1, ReviewerId = 2, Rating = 4, Message = "Very Good" });
                         context.Reviews.Add(new PostReview { PostId = 2, ReviewerId = 2, Rating = 4, Message = "Excelent" });
                         context.Reviews.Add(new PostReview { PostId = 2, ReviewerId = 1, Rating = 3, Message = "Good" });
                         context.Reviews.Add(new PostReview { PostId = 3, ReviewerId = 1, Rating = 5, Message = "Fantastic" });
                    }

                    context.SaveChanges();
               }
          }

     }
}
