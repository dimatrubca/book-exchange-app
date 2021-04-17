using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class BookDetailsConfig : IEntityTypeConfiguration<BookDetails>
     {
          public void Configure(EntityTypeBuilder<BookDetails> builder)
          {
               builder.Property(x => x.Publisher)
                    .HasMaxLength(100);
          }
     }
}
