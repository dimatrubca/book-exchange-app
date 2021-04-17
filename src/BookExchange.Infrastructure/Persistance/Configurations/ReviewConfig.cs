using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class ReviewConfig : IEntityTypeConfiguration<Review>
     {
          public void Configure(EntityTypeBuilder<Review> builder)
          {
               builder.Property(x => x.Message)
                    .IsRequired()
                    .HasMaxLength(3000);

               builder.HasOne(x => x.Reviewer)
                    .WithMany()
                    .HasForeignKey(x => x.ReviewerId)
                    .IsRequired();
          }
     }
}
