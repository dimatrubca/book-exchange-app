using BookExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Infrastructure.Persistance.Configurations
{
     public class RequestConfig : IEntityTypeConfiguration<Request>
     {
          public void Configure(EntityTypeBuilder<Request> builder)
          {
               // indirect m2m
               builder.HasOne(x => x.User)
                    .WithMany(x => x.Requests);

               builder.HasOne(x => x.Post)
                    .WithMany(x => x.Requests);

               builder.HasKey(x => new { x.UserId, x.PostId });
               builder.Ignore(x => x.Id);
          }
     }
}
