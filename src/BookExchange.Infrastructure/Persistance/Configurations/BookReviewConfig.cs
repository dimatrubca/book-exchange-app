using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class BookReviewConfig : IEntityTypeConfiguration<BookReview>
     {
          public void Configure(EntityTypeBuilder<BookReview> builder)
          {
              // builder.Property(x => x.Id).ValueGeneratedNever();
              // builder.Property(x => x.UserId).HasDefaultValue(1);
             //  builder.Ignore(x => x.Id);
          }
     }
}
