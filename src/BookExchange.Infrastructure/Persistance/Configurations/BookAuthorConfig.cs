using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
     {
          public void Configure(EntityTypeBuilder<BookAuthor> builder)
          {
               builder.HasOne(b => b.Book)
                    .WithMany()
                    .HasForeignKey(b => b.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

               builder.HasOne(b => b.Author)
                    .WithMany()
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
          }
     }
}
