using BookExchange.Domain.Models;
using BookExchange.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance
{
     public class BookExchangeDbContext : DbContext
     {
          private readonly string _connectionString;
          private DbConnection _connection;

          public DbSet<User> Users { get; set; }
          public DbSet<Post> Posts { get; set; }
          public DbSet<Review> Reviews { get; set; }
          public DbSet<Deal> Deals { get; set; }
          public DbSet<Book> Books { get; set; }
          public DbSet<WishList> WishList { get; set; }
          public DbSet<Request> Requests { get; set; }
          public DbSet<Bookmark> Bookmarks { get; set; }
          public DbSet<Author> Authors { get; set; }

          public BookExchangeDbContext(DbContextOptions<BookExchangeDbContext> options)
              : base(options)
          {
          }

          public BookExchangeDbContext(string connectionString)
          {
               _connectionString = connectionString;
          }

          public BookExchangeDbContext(DbConnection connection)
          {
               _connection = connection;
          }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               if (!optionsBuilder.IsConfigured)
               {
                    if (_connection != null)
                    {
                         optionsBuilder.UseSqlServer(_connection);
                    } else {
                         optionsBuilder.UseSqlServer(_connectionString);
                    }
               }
          }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               modelBuilder.ApplyConfiguration(new UserConfig());
               modelBuilder.ApplyConfiguration(new UserContactConfig());
               modelBuilder.ApplyConfiguration(new PostConfig());
               modelBuilder.ApplyConfiguration(new BookConfig());
               modelBuilder.ApplyConfiguration(new BookDetailsConfig());
               modelBuilder.ApplyConfiguration(new DealConfig());
               modelBuilder.ApplyConfiguration(new RequestConfig());
               modelBuilder.ApplyConfiguration(new ReviewConfig());
               modelBuilder.ApplyConfiguration(new BookAuthorConfig());

               modelBuilder.Entity<BookReview>().ToTable("BookReviews");
               modelBuilder.Entity<PostReview>().ToTable("PostReviews");
          }
     }
}
