using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class UserConfig : IEntityTypeConfiguration<User>
     {
          public void Configure(EntityTypeBuilder<User> builder)
          {
               builder.HasIndex(x => x.Username)
                    .IsUnique();

               builder.Property(x => x.FirstName)
                    .HasMaxLength(100);

               builder.Property(x => x.LastName)
                    .HasMaxLength(100);


               builder.Property(x => x.Username)
                    .IsRequired()
                    .HasMaxLength(100);


               builder.Property(x => x.Points)
                    .HasDefaultValue(0)
                    .HasColumnType("decimal(10, 2)");

               builder.HasMany(x => x.BookmarkedPosts)
                    .WithMany(x => x.BookmarkedBy)
                    .UsingEntity<Bookmark>(
                         x => x.HasOne(x => x.Post).WithMany(),
                         x => x.HasOne(x => x.User).WithMany()
                    ); 

               
               builder.HasMany(x => x.WishedBooks)
                    .WithMany(x => x.WishedBy)
                    .UsingEntity<WishList>(
                         x => x.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId),
                         x => x.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId)
                    );

               builder.HasMany(x => x.Posts)
                    .WithOne(x => x.PostedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

               builder.HasOne(x => x.UserContact)
                    .WithOne(x => x.User)
                    .OnDelete(DeleteBehavior.Cascade);

               builder.Property(x => x.RowVersion)
                    .IsRowVersion();

          }
     }
}
