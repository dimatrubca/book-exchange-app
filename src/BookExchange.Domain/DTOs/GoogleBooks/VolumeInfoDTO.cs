using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Domain.DTOs.GoogleBooks
{
     public class VolumeInfo
     {
          public string title { get; set; }
          public string subtitle { get; set; }
          public List<string> authors { get; set; }
          public string publisher { get; set; }
          public string description { get; set; }
          public string publishedDate { get; set; }
          public List<IndustryIdentifiersDTO> industryIdentifiers { get; set; }
          public int pageCount { get; set; }
          public string printType { get; set; }
          public List<string> categories { get; set; }
          public int averageRating { get; set; }
          public int ratingsCount { get; set; }
          public string maturityRating { get; set; }
          public bool allowAnonLogging { get; set; }
          public string contentVersion { get; set; }
          public ImageLinksDTO imageLinks { get; set; }
          public string language { get; set; }
          public string previewLink { get; set; }
          public string infoLink { get; set; }
          public string canonicalVolumeLink { get; set; }
     }
}
