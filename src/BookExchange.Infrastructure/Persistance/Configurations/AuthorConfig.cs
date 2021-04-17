using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class AuthorConfig : IEntityTypeConfiguration<Author>
     {
          public void Configure(EntityTypeBuilder<Author> builder)
          {
               builder.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();
          }
     }
}
