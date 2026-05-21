using System;
using System.Collections.Generic;
using System.Linq;
using Litforge.Data;
using Litforge.Models;

namespace Litforge
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (_context.Books.Any())
                return;

            // Countries
            var countries = new List<Country>
            {
                new Country { Name = "United States" },
                new Country { Name = "France" },
                new Country { Name = "Japan" }
            };

            // Authors
            var authors = new List<Author>
            {
                new Author { Name = "John Smith", Bio = "American novelist", CountryInfo = countries[0] },
                new Author { Name = "Marie Dubois", Bio = "French historical author", CountryInfo = countries[1] },
                new Author { Name = "Kenji Ito", Bio = "Japanese manga writer", CountryInfo = countries[2] }
            };

            // Categories
            var categories = new List<Category>
            {
                new Category { Name = "Fiction" },
                new Category { Name = "History" },
                new Category { Name = "Comics" }
            };

            // Books
            var books = new List<Book>
            {
                new Book
                {
                    Title = "The Great Adventure",
                    ReleaseDate = new DateTime(2020, 5, 10),
                    BookAuthors = new List<BookAuthor>(),
                    BookCategories = new List<BookCategory>()
                },
                new Book
                {
                    Title = "Echoes of the Past",
                    ReleaseDate = new DateTime(2019, 3, 22),
                    BookAuthors = new List<BookAuthor>(),
                    BookCategories = new List<BookCategory>()
                },
                new Book
                {
                    Title = "Samurai Tales",
                    ReleaseDate = new DateTime(2021, 11, 5),
                    BookAuthors = new List<BookAuthor>(),
                    BookCategories = new List<BookCategory>()
                }
            };

            // Book ↔ Author (many-to-many)
            books[0].BookAuthors.Add(new BookAuthor { Book = books[0], Author = authors[0] });
            books[1].BookAuthors.Add(new BookAuthor { Book = books[1], Author = authors[1] });
            books[2].BookAuthors.Add(new BookAuthor { Book = books[2], Author = authors[2] });

            // Book ↔ Category (many-to-many)
            books[0].BookCategories.Add(new BookCategory { Book = books[0], Category = categories[0] });
            books[1].BookCategories.Add(new BookCategory { Book = books[1], Category = categories[1] });
            books[2].BookCategories.Add(new BookCategory { Book = books[2], Category = categories[2] });

            // Reviewers
            var reviewers = new List<Reviewer>
            {
                new Reviewer { FirstName = "Alice", LastName = "Johnson" },
                new Reviewer { FirstName = "Bob", LastName = "Martin" }
            };

            // Reviews
            var reviews = new List<Review>
            {
                new Review
                {
                    Title = "Amazing read!",
                    Text = "Loved the characters and storyline.",
                    ReviewDate = DateTime.Now.AddDays(-10),
                    Reviewer = reviewers[0],
                    Book = books[0]
                },
                new Review
                {
                    Title = "Informative and engaging",
                    Text = "A great historical journey.",
                    ReviewDate = DateTime.Now.AddDays(-5),
                    Reviewer = reviewers[1],
                    Book = books[1]
                }
            };

            // Add to context
            _context.Countries.AddRange(countries);
            _context.Authors.AddRange(authors);
            _context.Categories.AddRange(categories);
            _context.Books.AddRange(books);
            _context.Reviewers.AddRange(reviewers);
            _context.Reviews.AddRange(reviews);

            _context.SaveChanges();
        }
    }
}