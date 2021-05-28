using BookExchange.Application.Common.Interfaces;
using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using C5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Common.Services
{
     public class RecommendationService : IRecommendationService
     {
          private readonly IBookRepository _bookRepository;
          private readonly IUserRepository _userRepository;
          private readonly ICategoryRepository _categoryRepository;
          private readonly IBookReviewRepository _bookReviews;


          public RecommendationService(IBookRepository bookRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IBookReviewRepository bookReviews)
          {
               _bookRepository = bookRepository;
               _userRepository = userRepository;
               _categoryRepository = categoryRepository;
               _bookReviews = bookReviews;
          }

          public class EvaluatedBook
          {
               public Book Book { get; set; }
               public double Score { get; set; }
          };

          public List<Book> RecommendBooks(int userId, int topN)
          {
               var categories = _categoryRepository.GetAll();
               var user = _userRepository.GetByIdWithInclude(userId, u => u.BookReviews);
               var userBookReviews = _bookReviews.GetUserBookReviews(userId); // include category

               Dictionary<int, double> userPreferences = new Dictionary<int, double>();

               foreach (var review in userBookReviews)
               {
                    var bookCategories = review.Book.Categories.ToList();

                    foreach (var category in bookCategories)
                    {
                         userPreferences[category.Id] = userPreferences.GetValueOrDefault(category.Id) + 1;
                    }
               }

               NormalizeValues(userPreferences);

               var evaluatedBooks = new List<EvaluatedBook>();
               var allBooks = _bookRepository.GetAllWithInclude(b => b.Categories);

               foreach (var book in allBooks)
               {
                    var bookFeatures = new Dictionary<int, double>();

                    foreach (var category in book.Categories)
                    {
                         bookFeatures[category.Id] = bookFeatures.GetValueOrDefault(category.Id) + 1;
                    }

                    NormalizeValues(bookFeatures);

                    var score = ComputeBookScore(bookFeatures, userPreferences);
                    evaluatedBooks.Add(new EvaluatedBook
                    {
                         Book = book,
                         Score = score
                    });
               }

               evaluatedBooks.Sort((p, q) => q.Score.CompareTo(p.Score)); // check if sorts desc

               return evaluatedBooks.Select(b => b.Book).Take(topN).ToList();
          }

          private void NormalizeValues<TKey>(Dictionary<TKey, double> dict)
          {
               double sum = dict.Sum(x => x.Value);

               foreach (var key in dict.Keys.ToList())
               {
                    dict[key] = dict[key] / sum;
               }
          }


          private double ComputeBookScore(Dictionary<int, double> userPreferences, Dictionary<int, double> bookFeatures)
          {
               double score = 0.0;

               foreach (var key in userPreferences.Keys.ToList())
               {
                    score += userPreferences[key] * bookFeatures.GetValueOrDefault(key);
               }

               return score;
          }
     }
}
