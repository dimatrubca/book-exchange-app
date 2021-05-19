using BookExchange.Domain.Interfaces;
using BookExchange.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Common
{
     public static class ServiceUtils
     {
          public static async Task<string> SaveFile(IFormFile file, string directory)
          {
               if (file == null || file.Length == 0) return null;

               string savePath = Path.Combine(directory, file.FileName);
               using (var fileStream = new FileStream(savePath, FileMode.Create))
               {
                    await file.CopyToAsync(fileStream);
               }

               return savePath;
          }

          public static bool CheckBookWithIsbnExists(IBookRepository bookRepository, string ISBN)
          {
               return bookRepository.GetBooksByCondition(b => b.ISBN == ISBN).Any();
          }

          public static bool CheckBookCategoryExists(IRepositoryBase<BookCategory> categoryRepository, string label)
          {
               return categoryRepository.GetAllByCondition(c => c.Label == label).Any();
          }
     }
}
