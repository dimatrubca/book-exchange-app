using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class PostConfig : IEntityTypeConfiguration<Post>
     {
          public void Configure(EntityTypeBuilder<Post> builder)
          {
               builder.Property(x => x.TimeAdded)
                    .HasDefaultValueSql("getdate()");

               builder.Property(x => x.Status)
                    .HasDefaultValue(PostStatus.Enabled)
                    .HasConversion(
                         x => x.ToString(),
                         x => (PostStatus)Enum.Parse(typeof(PostStatus), x));
          }
     }
}
