using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class ConditionConfig : IEntityTypeConfiguration<Condition>
     {
          public void Configure(EntityTypeBuilder<Condition> builder)
          {
               builder.Property(x => x.Label)
                    .HasMaxLength(30)
                    .IsRequired(true);

               builder.Property(x => x.Description)
                    .IsRequired(true);
          }
     }
}
