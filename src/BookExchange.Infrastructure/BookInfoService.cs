using BookExchange.Domain.DTOs;
using BookExchange.Domain.DTOs.GoogleBooks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookExchange.Services
{
     public class BookInfoService
     {

          public async Task<BookInfoDTO> GetBookByISBN(string isbn) {
               string url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&key=AIzaSyA0rsasAVTOr-CLw4JRMyzqAnMpzGR2DN0";
               HttpClient http = new HttpClient();
               string data = await http.GetAsync(url).Result.Content.ReadAsStringAsync();

               BookVolumesDTO volumes = JsonConvert.DeserializeObject<BookVolumesDTO>(data);
               
               if (volumes.totalItems == 0 || volumes.items == null || volumes.items.Count == 0) {
                    return null;
               }

               VolumeInfo volumeInfo = volumes.items[0].volumeInfo;

               BookInfoDTO book = new BookInfoDTO {
                    Title = volumeInfo.title,
                    Authors = volumeInfo.authors,
                    Description = volumeInfo.description,
                    Publisher = volumeInfo.publisher,
                    isbn13 = isbn,
                    Categories = volumeInfo.categories,
                    SmallThumbnailLink = volumeInfo.imageLinks.smallThumbnail,
                    ThumbnailLink = volumeInfo.imageLinks.thumbnail
               };

               return book;
          }
     }
}
