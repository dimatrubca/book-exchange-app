using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class BookConfig : IEntityTypeConfiguration<Book>
     {
          public void Configure(EntityTypeBuilder<Book> builder)
          {
               builder.HasIndex(b => b.ISBN)
                    .IsUnique();

               builder.Property(x => x.ISBN)
                    .HasColumnType("varchar")
                    .HasMaxLength(13);

               builder.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(100);

               builder.Property(x => x.ISBN)
                    .IsRequired()
                    .HasMaxLength(13);
               
               builder.HasMany(x => x.Authors)
                    .WithMany(x => x.Books)
                    .UsingEntity<BookAuthor>(
                         x => x.HasOne(x => x.Author).WithMany(),
                         x => x.HasOne(x => x.Book).WithMany(x => x.BookAuthor)
                    );

               builder.HasMany(x => x.Categories)
                    .WithMany(x => x.Books)
                    .UsingEntity<BookCategory>(
                         x => x.HasOne(x => x.Category).WithMany().HasForeignKey(b => b.CategoryId),
                         x => x.HasOne(x => x.Book).WithMany().HasForeignKey(b => b.BookId)
                    ); 
          }
     }
}
