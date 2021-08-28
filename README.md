# book-exchange-app (ASP.Net Core Web API + React)
BookExchangeApp is a fully functioning application that allows users to exchange books, earn and buy points, and receive recomendations based on the rated books.

## Components
- src/BookExchange.API - ASP.NET Core Web API (CQRS pattern)
- src/BookExchange.Application
- src/BookExchange.Domain
- src/BookExchange.IdentityServer - for authentication
- src/BookExchange.React - Client

## Key Features 
* Integration with ElasticSearch for smart search of books (via keywords inside the title/description/author)
* Authentication as a service (IdentityServer4).
* Integration with payment systems (PayPal)

## Basic Functionality
- Post/request/add book to wishlist
- Filtered search of books
- Point system for exchanging books
- Book recomendation system (content-based filtering)


## BookExchange.API
The design of the Web API follows CQRS pattern, that allows intercating with the main database (SQL Server) and ElasticSearch, for smart search of books.

## BookExchange.Application
Application layer of the web application, containing queries and commands for each entity, as well as the book recommendation service, based on the content-filtering algorithm.

## BookExchange.Domain
Contain domain models, their configurations and repositories

## BookExchange.Infrastructure
Contains the implementation of repositories for interacting with databases and dbContext.

SQL Server acts as a main database, which contains all of the data. ElasticSearch db contains only the information of books and allows to perform smart queries.

## BookExchange.IdentityServer
Authentication is implemented as a server, following resource owner credentials workflow and using IdentityServer4.

## BookExchange.React
Client side of the application.
