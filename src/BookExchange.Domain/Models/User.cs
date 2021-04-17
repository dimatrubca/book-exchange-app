﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     public class User : BaseEntity
     {
          public string Username { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public string Password { get; set; }
          public decimal Points { get; set; }
          public virtual UserContact UserContact { get; set; } 
          public virtual ICollection<Post> Posts { get; set; }
          public virtual ICollection<Post> BookmarkedPosts { get; set; }
          public virtual ICollection<Book> WishedBooks { get; set; }
          public virtual ICollection<Deal> Deals { get; set; }
          public virtual ICollection<Request> Requests { get; set; }
          //public virtual ICollection<Post> RequestedPosts { get; set; }

          public byte[] RowVersion { get; set; }
     }
}