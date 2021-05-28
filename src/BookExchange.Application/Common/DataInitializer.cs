using BookExchange.Application.Books.Events;
using BookExchange.Domain.Models;
using BookExchange.Infrastructure.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Application.Common
{
     public static class DataInitializer
     {
          public static void SeedDatabase(BookExchangeDbContext context, IMediator mediator)
          {
               context.Database.EnsureCreated();


               // create 3 users
               if (!context.Users.Any())
               {
                    var user1 = new User
                    {
                         Username = "dimatrubca",
                         FirstName = "Dima",
                         LastName = "Trubca",
                         Points = 10,
                         IdentityId = "1",
                         UserContact = new UserContact { Email = "dimatrubca@gmail.com" }
                    };


                    var user2 = new User
                    {
                         Username = "valentin",
                         FirstName = "Valentin",
                         LastName = "Korotkevichi",
                         Points = 5,
                         IdentityId = "2",
                         UserContact = new UserContact { Email = "dimatrubca@outlook.com" },
                    };
                    var user3 = new User
                    {
                         Username = "igor431",
                         FirstName = "Igor",
                         LastName = "Korotkevichi",
                         Points = 5,
                         IdentityId = "3",
                         UserContact = new UserContact { Email = "igor431@outlook.com" },
                    };

                    context.Users.Add(user1);
                    context.SaveChanges();
                    context.Users.Add(user2);
                    context.SaveChanges();
                    context.Users.Add(user3);
               }

               context.SaveChanges();



               if (!context.Set<Category>().Any())
               {
                    context.Add(new Category { Label = "Novel" });
                    context.Add(new Category { Label = "Fiction" });
                    context.SaveChanges();
                    context.Add(new Category { Label = "Non-Fiction" });
                    context.SaveChanges();
                    context.Add(new Category { Label = "War story" });
                    context.Add(new Category { Label = "Thriller" });
                    context.Add(new Category { Label = "Contemporary" });
                    context.Add(new Category { Label = "Science" });
                    context.SaveChanges();
               }

               if (!context.Set<Author>().Any())
               {
                    context.Authors.Add(new Author { Name = "Leo Tolstoy" });
                    context.SaveChanges();
                    context.Authors.Add(new Author { Name = "Greg McKewn" });
                    context.Authors.Add(new Author { Name = "John Green" });
                    context.SaveChanges();
                    context.Authors.Add(new Author { Name = "Yuval Noah Harari" });
                    context.Authors.Add(new Author { Name = "Carl Sagan" });
                    context.SaveChanges();
                    context.Authors.Add(new Author { Name = "Bill Bryson" });
                    context.SaveChanges();
               }

               if (context.Books.Any()) return;

               var book1 = new Book
               {
                    ISBN = "9780786112517",
                    Title = "War and Peace",
                    ShortDescription = "War and Peace is a novel by the Russian author Leo Tolstoy, first published serially, then published in its entirety in 1869. It is regarded as one of Tolstoy's finest literary achievements and remains an internationally praised classic of world literature.",
                    ThumbnailPath = @"uploads\books\war-and-peace.jpg",
                    Details = new BookDetails
                    {
                         Description = "War and Peace broadly focuses on Napoleon’s invasion of Russia in 1812 and follows three of the most well-known characters in literature: Pierre Bezukhov, the illegitimate son of a count who is fighting for his inheritance and yearning for spiritual fulfillment; Prince Andrei Bolkonsky, who leaves his family behind to fight in the war against Napoleon; and Natasha Rostov, the beautiful young daughter of a nobleman who intrigues both men. A s Napoleon’s army invades, Tolstoy brilliantly follows characters from diverse backgrounds—peasants and nobility, civilians and soldiers—as they struggle with the problems unique to their era, their history, and their culture. And as the novel progresses, these characters transcend their specificity, becoming some of the most moving—and human—figures in world literature.",
                         PageCount = 300,
                         Publisher = "Vintage",
                         PublishedYear  = 1867,
                         ImagePath = @"uploads\books\war-and-peace.jpg",
                    },
               };

               var book2 = new Book
               {
                    ISBN = "9788807900501",
                    Title = "A Confession",
                    ShortDescription = "A Confession, or My Confession, is a short work on the subject of melancholia, philosophy and religion by the acclaimed Russian novelist Leo Tolstoy. It was written in 1879 to 1880, when Tolstoy was in his early fifties.",
                    ThumbnailPath = @"uploads\books\confession.jpg",
                    Details = new BookDetails
                    {
                         Description = "'A Confession' is Tolstoy's chronicle of his journey to faith; his account of how he moved from despair to the possibility of living; from unhappy existence to 'the glow and strength of life'. It describes his spiritual and philosophical struggles up until he leaves the Orthodox Church, convinced that humans discover truth not by faith, but by reason. The story begins when at the age of 50, Tolstoy is in crisis. Having found no peace in art, science or philosophy, he is attacked by the black dog of despair, and considers suicide. His past life is reappraised and found wanting; as slowly light dawns within. 'As gradually, imperceptibly as life had decayed in me, until I reached the impossibility of living, so gradually I felt the glow and strength of life return to me... I returned to a belief in God.' Here is a quest for meaning at the close of the 19th century - a time of social, scientific and intellectual turbulence, in which old forms were under threat. Tolstoy looks around at both old and new alike, and like the author of Ecclesiastes, discovers that 'All is vanity'. His spiritual discoveries first take him into the arms of the Orthodox Church; and then force his angry departure from it. 'My Religion' carries on from where 'A Confession' left off. Describing himself as a former nihilist, Tolstoy develops his attack on the church he has left. He accuses them of hiding the true meaning of Jesus, which is to be found in the Sermon on the Mount; and most clearly, in the call not to resist evil. For Tolstoy, it is this command which has been most damaged by ecclesiastical interpretation. 'Not everyone,' he writes, 'is able to understand the mysteries of dogmatics, homilectics, liturgics, hermeneutics, apologetics; but everyone is able and ought to understand what Christ said to the millions of simple and ignorant people who have lived and are living today.' Here is Tolstoy's religion; and non-violence is at its heart. Simon Parke, author of The Beautiful Life",
                         PageCount = 104,
                         Publisher = "White Crow Books",
                         PublishedYear = 1888,
                         ImagePath = @"uploads\books\confession.jpg",
                    },
               };

               var book3 = new Book
               {
                    ISBN = "9780786105236",
                    Title = "The Cossacks",
                    ShortDescription = "The Cossacks is a short novel by Leo Tolstoy, published in 1863 in the popular literary magazine The Russian Messenger",
                    ThumbnailPath = @"uploads\books\The-Cossacks-cover.jpg",
                    Details = new BookDetails
                    {
                         Description = "Long Description3 just",
                         PageCount = 150,
                         Publisher = "PublisherName",
                         PublishedYear = 1909,
                         ImagePath = @"uploads\books\The-Cossacks-cover.jpg"
                    },
               };

               var book4 = new Book
               {
                    ISBN = "9781455869749",
                    Title = "The Fault in Our Stars",
                    ShortDescription = "Two cancer-afflicted teenagers Hazel and Augustus meet at a cancer support group. The two of them embark on a journey to visit a reclusive author in Amsterdam.",
                    ThumbnailPath = @"uploads\books\ourstars.jpg",
                    Details = new BookDetails
                    {
                         Description = "Despite the tumor-shrinking medical miracle that has bought her a few years, Hazel has never been anything but terminal, her final chapter inscribed upon diagnosis. But when a gorgeous plot twist named Augustus Waters suddenly appears at Cancer Kid Support Group, Hazel's story is about to be completely rewritten. Insightful, bold, irreverent, and raw, The Fault in Our Stars is award-winning author John Green's most ambitious and heartbreaking work yet, brilliantly exploring the funny, thrilling, and tragic business of being alive and in love.",
                         PageCount = 352,
                         Publisher = "Penguin Books",
                         PublishedYear = 2014,
                         ImagePath = @"uploads\books\ourstars.jpg"
                    },
               };

               var book5 = new Book
               {
                    ISBN = "9781494506902",
                    Title = "Sapiens: A Brief History of Humankind",
                    ShortDescription = "Sapiens: A Brief History of Humankind is a book by Yuval Noah Harari, first published in Hebrew in Israel in 2011 based on a series of lectures Harari taught at The Hebrew University of Jerusalem, and in English in 2014",
                    ThumbnailPath = @"uploads\books\sapiens.jpg",
                    Details = new BookDetails
                    {
                         Description = "From a renowned historian comes a groundbreaking narrative of humanity’s creation and evolution—a #1 international bestseller—that explores the ways in which biology and history have defined us and enhanced our understanding of what it means to be “human.” One hundred thousand years ago, at least six different species of humans inhabited Earth. Yet today there is only one—homo sapiens. What happened to the others? And what may happen to us? Most books about the history of humanity pursue either a historical or a biological approach, but Dr. Yuval Noah Harari breaks the mold with this highly original book that begins about 70,000 years ago with the appearance of modern cognition. From examining the role evolving humans have played in the global ecosystem to charting the rise of empires, Sapiens integrates history and science to reconsider accepted narratives, connect past developments with contemporary concerns, and examine specific events within the context of larger ideas. Dr. Harari also compels us to look ahead, because over the last few decades humans have begun to bend laws of natural selection that have governed life for the past four billion years. We are acquiring the ability to design not only the world around us, but also ourselves. Where is this leading us, and what do we want to become? Featuring 27 photographs, 6 maps, and 25 illustrations/diagrams, this provocative and insightful work is sure to spark debate and is essential reading for aficionados of Jared Diamond, James Gleick, Matt Ridley, Robert Wright, and Sharon Moalem.",
                         PageCount = 443,
                         Publisher = "Harper",
                         PublishedYear = 2015,
                         ImagePath = @"uploads\books\sapiens.jpg",
                    }
               };

               var book6 = new Book
               {
                    ISBN = "9780552562966",
                    Title = "A Short History of Nearly Everything",
                    ShortDescription = "A Short History of Nearly Everything by American-British author Bill Bryson is a popular science book that explains some areas of science, using easily accessible language that appeals more to the general public than many other books dedicated to the subject",
                    ThumbnailPath = @"uploads\books\brief-history-of-nearly-everything.jpg",
                    Details = new BookDetails
                    {
                         Description = "In Bryson's biggest book, he confronts his greatest challenge: to understand—and, if possible, answer—the oldest, biggest questions we have posed about the universe and ourselves. Taking as territory everything from the Big Bang to the rise of civilization, Bryson seeks to understand how we got from there being nothing at all to there being us. To that end, he has attached himself to a host of the world’s most advanced (and often obsessed) archaeologists, anthropologists, and mathematicians, travelling to their offices, laboratories, and field camps. He has read (or tried to read) their books, pestered them with questions, apprenticed himself to their powerful minds. A Short History of Nearly Everything is the record of this quest, and it is a sometimes profound, sometimes funny, and always supremely clear and entertaining adventure in the realms of human knowledge, as only Bill Bryson can render it. Science has never been more involving or entertaining.",
                         PageCount = 544,
                         Publisher = "Broadway Books",
                         PublishedYear = 2004,
                         ImagePath = @"uploads\books\brief-history-of-nearly-everything.jpg",
                    }
               };


               var book7 = new Book
               {
                    ISBN = "9780345331359",
                    Title = "Cosmos",
                    ShortDescription = "Cosmos is a 1980 popular science book by astronomer and Pulitzer Prize-winning author Carl Sagan. Its 13 illustrated chapters, corresponding to the 13 episodes of the Cosmos TV series, which the book was co-developed with and intended to complement, explore the mutual development of science and civilization.",
                    ThumbnailPath = @"uploads\books\cosmos.jpg",
                    Details = new BookDetails
                    {
                         Description = "This visually stunning book with over 250 full-color illustrations, many of them never before published, is based on Carl Sagan’s thirteen-part television series. Told with Sagan’s remarkable ability to make scientific ideas both comprehensible and exciting, Cosmos is about science in its broadest human context, how science and civilization grew up together. The book also explores spacecraft missions of discovery of the nearby planets, the research in the Library of ancient Alexandria, the human brain, Egyptian hieroglyphics, the origin of life, the death of the Sun, the evolution of galaxies and the origins of matter, suns and worlds. Sagan retraces the fifteen billion years of cos-mic evolution that have transformed matter into life and consciousness, enabling the Cosmos to wonder about itself. He considers the latest findings on life elsewhere and how we might communicate with the beings of other worlds. Cosmos is the story of our long journey of discovery and the forces and individuals who helped to shape modern science, including Democritus, Hypatia, Kepler, Newton, Huy-gens, Champollion, Lowell and Humason. Sagan looks at our planet from an extra-terrestrial vantage point and sees a blue jewel-like world, inhabited by a lifeform that is just beginning to discover its own unity and to ven-ture into the vast ocean of space.",
                         PageCount = 384,
                         Publisher = "Random House",
                         PublishedYear = 2002,
                         ImagePath = @"uploads\books\cosmos.jpg",
                    }
               };

               context.Books.Add(book1);
               context.SaveChanges();
               context.Books.Add(book2);
               context.SaveChanges();
               context.Books.Add(book3);
               context.SaveChanges();
               context.Books.Add(book4);
               context.SaveChanges();
               context.Books.Add(book5);
               context.SaveChanges();
               context.Books.Add(book6);
               context.SaveChanges();
               context.Books.Add(book7);
               context.SaveChanges();


               if (!context.Set<BookAuthor>().Any())
               {
                    context.Add(new BookAuthor { BookId = 1, AuthorId = 1 });
                    context.Add(new BookAuthor { BookId = 2, AuthorId = 1 });
                    context.Add(new BookAuthor { BookId = 3, AuthorId = 1 });
                    context.Add(new BookAuthor { BookId = 4, AuthorId = 3 });
                    context.Add(new BookAuthor { BookId = 5, AuthorId = 4 });
                    context.Add(new BookAuthor { BookId = 6, AuthorId = 6 });
                    context.Add(new BookAuthor { BookId = 7, AuthorId = 6 });
               }


               if (!context.Set<BookCategory>().Any())
               {
                    context.Add(new BookCategory { BookId = 1, CategoryId = 1 });
                    context.Add(new BookCategory { BookId = 1, CategoryId = 2 });
                    context.Add(new BookCategory { BookId = 1, CategoryId = 4 });

                    context.Add(new BookCategory { BookId = 2, CategoryId = 1 });
                    context.Add(new BookCategory { BookId = 2, CategoryId = 2 });

                    context.Add(new BookCategory { BookId = 3, CategoryId = 1 });
                    context.Add(new BookCategory { BookId = 3, CategoryId = 2 });

                    context.Add(new BookCategory { BookId = 4, CategoryId = 1 });

                    context.Add(new BookCategory { BookId = 5, CategoryId = 3 });
                    context.Add(new BookCategory { BookId = 5, CategoryId = 7 });

                    context.Add(new BookCategory { BookId = 6, CategoryId = 3 });
                    context.Add(new BookCategory { BookId = 6, CategoryId = 7 });


                    context.Add(new BookCategory { BookId = 7, CategoryId = 3 });
                    context.Add(new BookCategory { BookId = 7, CategoryId = 7 });
               }

               context.SaveChanges();

               


               if (context.Users.Count() >= 3)
               {

                    var post1 = new Post { PostedById = 1, BookId = 1, Condition = Condition.New };
                    var post2 = new Post { PostedById = 1, BookId = 6, Condition = Condition.New };
                    var post3 = new Post { PostedById = 1, BookId = 5, Condition = Condition.Acceptable };
                    var post4 = new Post { PostedById = 1, BookId = 4, Condition = Condition.New };


                    var post5 = new Post { PostedById = 2, BookId = 5, Condition = Condition.New };
                    var post6 = new Post { PostedById = 2, BookId = 6, Condition = Condition.New };

                    var post7 = new Post { PostedById = 3, BookId = 2, Condition = Condition.New };
                    var post8 = new Post { PostedById = 3, BookId = 6, Condition = Condition.New };
                    var post9 = new Post { PostedById = 3, BookId = 7, Condition = Condition.New };

                    context.Posts.Add(post1);
                    context.SaveChanges();
                    context.Posts.Add(post2);
                    context.SaveChanges();
                    context.Posts.Add(post3);
                    context.SaveChanges();
                    context.Posts.Add(post4);
                    context.Posts.Add(post5);
                    context.SaveChanges();
                    context.Posts.Add(post6);
                    context.Posts.Add(post7);
                    context.SaveChanges();
                    context.Posts.Add(post8);
                    context.Posts.Add(post9);

                    context.SaveChanges();
               }


               // populate wishlist table
               if (!context.Wishlist.Any())
               {
                    context.Wishlist.Add(new Wishlist { UserId = 1, BookId = 7 });
                    context.Wishlist.Add(new Wishlist { UserId = 1, BookId = 3 });

                    context.Wishlist.Add(new Wishlist { UserId = 2, BookId = 1 });
                    context.Wishlist.Add(new Wishlist { UserId = 2, BookId = 2 });

                    context.Wishlist.Add(new Wishlist { UserId = 3, BookId = 3 });
                    context.Wishlist.Add(new Wishlist { UserId = 3, BookId = 4 });
               }

               if (!context.Deals.Any())
               {
                    context.Deals.Add(new Deal { BookTakerId = 1, PostId = 6, DealStatus=DealStatus.InDelivery });
                    context.Deals.Add(new Deal { BookTakerId = 1, PostId = 2, DealStatus = DealStatus.Delivered });
               }

               context.SaveChanges();


               // populate requests table
               if (!context.Requests.Any())
               {
                    context.Requests.Add(new Domain.Models.Request { PostId = 9, UserId = 1 });
                    context.Requests.Add(new Domain.Models.Request { PostId = 7, UserId = 1 });
                    context.Requests.Add(new Domain.Models.Request { PostId = 2, UserId = 2 });
               }

               context.SaveChanges();

               // populate bookmarks table
               if (!context.Bookmarks.Any())
               {
                    context.Bookmarks.Add(new Bookmark { UserId = 1, PostId = 4 });
                    context.Bookmarks.Add(new Bookmark { UserId = 1, PostId = 3 });
                    context.Bookmarks.Add(new Bookmark { UserId = 2, PostId = 2 });
               }
               context.SaveChanges();


               // populate book reviews
               if (!context.BookReviews.Any())
               {
                    context.BookReviews.Add(new BookReview { BookId = 1, UserId = 1, Rating = 5});
                    context.BookReviews.Add(new BookReview { BookId = 1, UserId = 1, Rating = 4 });
                    context.BookReviews.Add(new BookReview { BookId = 1, UserId = 1, Rating = 5 });
                    context.BookReviews.Add(new BookReview { BookId = 2, UserId = 2, Rating = 4 });
                    context.BookReviews.Add(new BookReview { BookId = 2, UserId = 2, Rating = 3 });
               }

               context.SaveChanges();

               mediator.Publish(new BookCreatedEvent
               {
                    Id = book1.Id,
                    Title = book1.Title,
                    ShortDescription = book1.ShortDescription,
                    Description = book1.Details.Description,
                    Authors = book1.Authors?.Select(a => a.Name).ToList(),
                    Categories = book1.Categories?.Select(a => a.Label).ToList()
               });

               mediator.Publish(new BookCreatedEvent
               {
                    Id = book2.Id,
                    Title = book2.Title,
                    ShortDescription = book2.ShortDescription,
                    Description = book2.Details.Description,
                    Authors = book2.Authors?.Select(a => a.Name).ToList(),
                    Categories = book2.Categories?.Select(a => a.Label).ToList()
               });

               mediator.Publish(new BookCreatedEvent
               {
                    Id = book3.Id,
                    Title = book3.Title,
                    ShortDescription = book3.ShortDescription,
                    Description = book3.Details.Description,
                    Authors = book3.Authors?.Select(a => a.Name).ToList(),
                    Categories = book3.Categories?.Select(a => a.Label).ToList()
               });

               mediator.Publish(new BookCreatedEvent
               {
                    Id = book4.Id,
                    Title = book4.Title,
                    ShortDescription = book4.ShortDescription,
                    Description = book4.Details.Description,
                    Authors = book4.Authors?.Select(a => a.Name).ToList(),
                    Categories = book4.Categories?.Select(a => a.Label).ToList()
               });

               mediator.Publish(new BookCreatedEvent
               {
                    Id = book5.Id,
                    Title = book5.Title,
                    ShortDescription = book5.ShortDescription,
                    Description = book5.Details.Description,
                    Authors = book5.Authors?.Select(a => a.Name).ToList(),
                    Categories = book5.Categories?.Select(a => a.Label).ToList()
               });

               mediator.Publish(new BookCreatedEvent
               {
                    Id = book6.Id,
                    Title = book6.Title,
                    ShortDescription = book6.ShortDescription,
                    Description = book6.Details.Description,
                    Authors = book6.Authors?.Select(a => a.Name).ToList(),
                    Categories = book6.Categories?.Select(a => a.Label).ToList()
               });

               mediator.Publish(new BookCreatedEvent
               {
                    Id = book7.Id,
                    Title = book7.Title,
                    ShortDescription = book7.ShortDescription,
                    Description = book7.Details.Description,
                    Authors = book7.Authors?.Select(a => a.Name).ToList(),
                    Categories = book7.Categories?.Select(a => a.Label).ToList()
               });
          }

     }
}
