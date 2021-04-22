using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class BaseEntity
     {
          [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
     }
}
