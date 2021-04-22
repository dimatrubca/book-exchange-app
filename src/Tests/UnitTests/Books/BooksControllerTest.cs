using BookExchange.API.Controllers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.UnitTests.Books
{
     [TestClass]
     public class BooksControllerTest
     {
          private readonly BookController bookController;
          private readonly Mock<IMediator> mediator = new Mock<IMediator>();
          /*
          public BooksControllerTest()
          {
               _bookController = bookController;
          }

          [TestMethod]
          public void ShouldReturn_GetAllBooks()
          {
               var books = 
          }*/
     }
}
