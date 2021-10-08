using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BookWebsite.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDBcontext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDBcontext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();

            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    //Populates the database with seed data
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        PageNumber = 1488,
                        BookPicURL = "https://m.media-amazon.com/images/I/51fyLYwnWwL.jpg"
                    },
                      new Book
                      {
                          Title = "Team of Rivals",
                          AuthorFirstName = "Doris",
                          AuthorMiddleInitial = "K.",
                          AuthorLastName = "Goodwin",
                          Publisher = "Simon and Schuster",
                          ISBN = "978-0743270755",
                          Classification = "Non-Fiction",
                          Category = "Biography",
                          Price = 14.58,
                          PageNumber = 944,
                          BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/516P3j+ulvL._SX331_BO1,204,203,200_.jpg"
                      },
                      new Book
                      {
                          Title = "The Snowball",
                          AuthorFirstName = "Alice",
                          AuthorLastName = "Schroeder",
                          Publisher = "Bantam",
                          ISBN = "978-0553384611",
                          Classification = "Non-Fiction",
                          Category = "Biography",
                          Price = 21.54,
                          PageNumber = 832,
                          BookPicURL = "https://m.media-amazon.com/images/I/51AVeE+kBkL.jpg"
                      },
                        new Book
                        {
                            Title = "American Ulysses",
                            AuthorFirstName = "Ronald",
                            AuthorMiddleInitial = "C.",
                            AuthorLastName = "White",
                            Publisher = "Random House",
                            ISBN = "978-0812981254",
                            Classification = "Non-Fiction",
                            Category = "Biography",
                            Price = 11.61,
                            PageNumber = 864,
                            BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/91E5LBRitRL.jpg"
                        },
                          new Book
                          {
                              Title = "Unbroken",
                              AuthorFirstName = "Laura ",
                              AuthorLastName = "Hillenbrand",
                              Publisher = "Random House",
                              ISBN = "978-0812974492",
                              Classification = "Non-Fiction",
                              Category = "Historical ",
                              Price = 13.33,
                              PageNumber = 528,
                              BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/91UmKFGfyYL.jpg"
                          },
                          new Book
                          {
                              Title = "The Great Train Robbery",
                              AuthorFirstName = "Michael",
                              AuthorLastName = "Crichton",
                              Publisher = "Vintage",
                              ISBN = "978-0804171281",
                              Classification = "Fiction",
                              Category = "Historical Fiction",
                              Price = 15.95,
                              PageNumber = 288,
                              BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/81xCabu8SML.jpg"
                          },

                            new Book
                            {
                                Title = "Deep Work",
                                AuthorFirstName = "Cal",
                                AuthorLastName = "Newport",
                                Publisher = "Grand Central Publishing",
                                ISBN = "978-1455586691",
                                Classification = "Non-Fiction",
                                Category = "Self-Help",
                                Price = 14.99,
                                PageNumber = 304,
                                BookPicURL = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1451409702l/28383248._SY475_.jpg"
                            },

                            new Book
                            {
                                Title = "It's Your Ship",
                                AuthorFirstName = "Michael",
                                AuthorLastName = "Abrashoff",
                                Publisher = "Grand Central Publishing",
                                ISBN = "978-1455523023",
                                Classification = "Non-Fiction",
                                Category = "Self-Help",
                                Price = 21.66,
                                PageNumber = 240,
                                BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/51D6CpYPkiL._SX330_BO1,204,203,200_.jpg"
                            },
                            new Book
                            {
                                Title = "The Virgin Way",
                                AuthorFirstName = "Richard",
                                AuthorLastName = "Branson",
                                Publisher = "Portfolio",
                                ISBN = "978-1591847984",
                                Classification = "Non-Fiction",
                                Category = "Business",
                                Price = 29.16,
                                PageNumber = 400,
                                BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/81yRzduL8VL.jpg"
                            },
                              new Book
                              {
                                  Title = "Sycamore Row",
                                  AuthorFirstName = "John",
                                  AuthorLastName = "Grisham",
                                  Publisher = "Bantam",
                                  ISBN = "978-0553393613",
                                  Classification = "Fiction",
                                  Category = "Thrillers",
                                  Price = 15.03,
                                  PageNumber = 642,
                                  BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/51BhzoOnoNL.jpg"
                              },
                                 new Book
                                 {
                                     Title = "Flags of our Fathers",
                                     AuthorFirstName = "James",
                                     AuthorLastName = "Bradley",
                                     Publisher = "Random House",
                                     ISBN = "978-0440229209",
                                     Classification = "Non-Fiction",
                                     Category = "Biography",
                                     Price = 17.52,
                                     PageNumber = 244,
                                     BookPicURL = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b8/FlagsOfOurFathers.jpg/220px-FlagsOfOurFathers.jpg"
                                 },
                                  new Book
                                  {

                                      Title = "Dustoff: The Memoir of an Army Aviator",
                                      AuthorFirstName = "Mike",
                                      AuthorLastName = "Novosel",
                                      AuthorMiddleInitial = "J.",
                                      Publisher = "Presidio Press",
                                      ISBN = " 978-0891418023",
                                      Classification = "Non-Fiction",
                                      Category = "Biography",
                                      Price = 12.61,
                                      PageNumber = 384,
                                      BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/418PNM914PL.jpg"
                                  },
                                    new Book
                                    {

                                        Title = "The Red Badge of Courage",
                                        AuthorFirstName = "Stephen",
                                        AuthorLastName = "Crane",
                                        Publisher = "CreateSpace",
                                        ISBN = "978-1508482765",
                                        Classification = "Historical Fiction",
                                        Category = "War",
                                        Price = 5.99,
                                        PageNumber = 88,
                                        BookPicURL = "https://images-na.ssl-images-amazon.com/images/I/51rjApeo6SL.jpg"
                                    }
                    ); 

                context.SaveChanges();
            }
        }
    }
}
