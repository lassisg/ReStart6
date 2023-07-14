using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E01_EF6_CF_DAL
{

    public static class BookRepository
    {

        #region CRUD Methods

        public static Book Create(this Book book)
        {

            using (var db = new LibraryContext())
            {
                db.Book.Add(book);

                db.SaveChanges();
            }

            return book;
        }

        public static Book GetBookById(int bookId)
        {

            Book book;

            using (var db = new LibraryContext())
            {
                book = db.Book.FirstOrDefault(b => b.BookId == bookId);
            }

            return book;

        }

        public static List<Book> GetAllBooks()
        {

            var allBooks = new List<Book>();

            using (var db = new LibraryContext())
            {
                allBooks = db.Book.Select(b => b).ToList();
            }

            return allBooks;

        }

        #endregion

        #region Utility methods

        public static string GetFormattedBook(this Book book)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id: {book.BookId}");
            sb.AppendLine($"Título: {book.Title}");
            sb.AppendLine($"ISBN: {book.ISBN}");
            sb.AppendLine($"Autor: {book.Author}");
            sb.AppendLine($"Editora: {PublisherRepository.GetPublisherById(book.PublisherId).Name}");

            if (book.PublishDate != null)
            {
                sb.AppendLine($"Publicado em: {book.PublishDate:MM/yyyy}");
            }

            sb.AppendLine("\n-------------------------------------------");

            return sb.ToString();
        }

        #endregion

        #region Validation methods

        public static Book ValidateBook(this Book book)
        {

            if (!(book.Title.Length > 0 && book.Title.Length <= 100))
                throw new InvalidOperationException("Limite de 100 caracteres.");

            if (!(book.Author.Length > 0 && book.Author.Length <= 100))
                throw new InvalidOperationException("Limite de 100 caracteres.");


            if (!(book.ISBN.Length >= 10 && book.ISBN.Length <= 1))
                throw new InvalidOperationException("Limite de 13 caracteres.");

            if (PublisherRepository.GetPublisherById(book.PublisherId) is null)
                throw new InvalidOperationException("Editora incorreta.");

            return book;

        }

        #endregion

    }

}
