using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E02_EF6_CF_Migrations_Books_DAL;

namespace E02_EF6_CF_Migrations_Books_Client
{

    static class BooksDBClient
    {

        public static void CreatePublisher()
        {

            var publisher = new Publisher
            {
                Name = "New publisher"
            };

            using (var context = new BooksDBContext())
            {
                context.Publisher.Add(publisher);
                context.SaveChanges();
            }

        }

        public static void CreateBook()
        {

            var book = new Book
            {
                PublisherID = 1,
                Title = "New book",
                ISBN = "123456789"
            };

            using (var context = new BooksDBContext())
            {
                context.Book.Add(book);
                context.SaveChanges();
            }
        }

    }

}
