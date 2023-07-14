using D03_EF6_CF_Migrations_Books_DAL;
using System;
using System.Linq;

namespace D03_EF6_CF_Migrations_Books_Client
{

    static class BookRepository
    {

        public static void CreateBook()
        {

            var book01 = new Book
            {
                PublisherID = 1,
                Title = "Book from publisher 1",
                ISBN = "123456789"
            };

            var book02 = new Book
            {
                PublisherID = 2,
                Title = "Book from publisher 2",
                ISBN = "234567890"
            };

            var book03 = new Book
            {
                PublisherID = 3,
                Title = "Book from publisher 3 to be deleted from publisher",
                ISBN = "345678901"
            };

            using (var context = new BooksDBContext())
            {
                context.Book.Add(book01);
                context.Book.Add(book02);
                context.Book.Add(book03);
                context.SaveChanges();
            }

        }

        public static void ReadBook()
        {

            using (var context = new BooksDBContext())
            {

                var query = context.Book.Select(b => b).OrderBy(b => b.BookID);

                Utility.WriteSubtitle("Books", "\n\n", "\n-----------------------");

                query.ToList().ForEach(b => Console.WriteLine($"{b.BookID} - {b.Title}"));

            }

        }

    }

}
