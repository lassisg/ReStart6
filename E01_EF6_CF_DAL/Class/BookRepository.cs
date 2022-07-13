using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_EF6_CF_DAL
{

    public static class BookRepository
    {

        #region Extended Methods

        public static void Create(this Book book)
        {

            using (var db = new LibraryContext())
            {
                db.Book.Add(book);

                db.SaveChanges();
            }

        }
        public static List<Book> ListAll()
        {

            var allBooks = new List<Book>();

            using (var db = new LibraryContext())
            {
                allBooks = db.Book.Select(b => b).ToList();
            }

            return allBooks;

        }

        #endregion

    }

}
