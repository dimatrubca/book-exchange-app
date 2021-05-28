using BookExchange.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Common.Interfaces
{
     public interface IRecommendationService
     {
          public List<Book> RecommendBooks(int userId, int topN);
     }
}
