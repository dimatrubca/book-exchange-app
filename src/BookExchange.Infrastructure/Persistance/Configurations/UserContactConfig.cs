using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class UserContactConfig : IEntityTypeConfiguration<UserContact>
     {
          public void Configure(EntityTypeBuilder<UserContact> builder)
          {
               builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(255);

               builder.Property(x => x.City)
                    .HasMaxLength(100);

               builder.Property(x => x.Country)
                    .HasMaxLength(100);

               builder.Property(x => x.Email)
                    .HasMaxLength(100);

               builder.Property(x => x.Region)
                    .HasMaxLength(100);

               builder.Property(x => x.StreetAddress)
                    .HasMaxLength(100);

               builder.Property(x => x.PhoneNumber)
                    .HasMaxLength(15);

               builder.Property(x => x.Region)
                    .HasMaxLength(100);
          }
     }
}
