using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class DealConfig : IEntityTypeConfiguration<Deal>
     {
          public void Configure(EntityTypeBuilder<Deal> builder)
          {
               builder.Property(x => x.TimeAdded)
                    .IsRequired()
                    .HasDefaultValueSql("getdate()");


               builder.Property(x => x.DealStatus)
                    .HasConversion<string>()
                    .HasDefaultValue(DealStatus.InDelivery)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
          }
     }
}
