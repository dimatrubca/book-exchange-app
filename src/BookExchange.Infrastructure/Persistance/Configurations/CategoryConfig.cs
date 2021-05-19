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
     public class CategoryConfig : IEntityTypeConfiguration<BookCategory>
     {
          public void Configure(EntityTypeBuilder<BookCategory> builder)
          {
               builder.Property(x => x.Label)
                    .IsRequired();

               
          }
     }
}
