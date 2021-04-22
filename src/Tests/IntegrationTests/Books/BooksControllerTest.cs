using BookExchange.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests.IntegrationTests.Books
{
     [TestClass]
     class BooksControllerTest
     {
          private readonly HttpClient _client;

          public BooksControllerTest()
          {
               var server = new TestServer(new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<Startup>());

               _client = server.CreateClient();
          }

          [TestMethod]
          public async Task GetBooks()
          {
               // Arrange
               var request = "/api/books";

               // Act
               var response = await _client.GetAsync(request);

               // Assert 
               response.EnsureSuccessStatusCode();
               //var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
               //var obj = JsonConvert.DeserializeObject(jsonFromPostResponse);
              
          }
     }
}
