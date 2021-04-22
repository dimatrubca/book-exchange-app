using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.Models
{
     /*
     public enum PostType { 
          Lend = 1, 
          GiveAway = 3,
     } // points value
     */
     public enum PostStatus { 
          Enabled, 
          Disabled
     }

     public class Post : BaseEntity
     {
          public int BookId { get; set; }
          public int? PostedById { get; set; }
          public int? ConditionId { get; set; }
          public PostStatus Status { get; set; }
          public DateTime TimeAdded { get; set; }

          public virtual Book Book { get; set; }
          public virtual User PostedBy { get; set; }
          public virtual Condition Condition { get; set; }
          public virtual ICollection<User> BookmarkedBy { get; set; }
          public virtual ICollection<Request> Requests { get; set; }
          //public ICollection<User> RequestedBy { get; set; }
          public virtual ICollection<Deal> Deals { get; set; }
          public virtual ICollection<PostReview> Reviews { get; set; }
          
     }
}

