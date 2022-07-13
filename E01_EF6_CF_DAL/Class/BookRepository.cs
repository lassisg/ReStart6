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

        #endregion

        #region Methods

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

        #region User interaction methods

        public static Book GetNewBook()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------\nAdicionar livro (Enter para sair)\n----------------------------------");
            var book = new Book();

            Console.Write("\nDigite o título do livro: ");
            string userInput = Console.ReadLine();
            book.Title = userInput;

            Console.Write("\nDigite o nome do autor: ");
            userInput = Console.ReadLine();
            book.Author = userInput;

            Console.Write("\nDigite o ISBN do livro: ");
            userInput = Console.ReadLine();
            book.ISBN = userInput;

            Console.WriteLine("\nSelecione a editora na lista abaixo.");
            var publishers = PublisherRepository.ListAll().OrderBy(p => p.PublisherId).ToList();
            publishers.ForEach(p => Console.WriteLine($"{p.PublisherId} - {p.Name}"));
            userInput = Console.ReadLine();

            _ = int.TryParse(userInput, out int publisherId);
            if (!publishers.Any(p => p.PublisherId == publisherId))
                throw new InvalidOperationException("\nEscolha inválida!\n");

            book.PublisherId = publisherId;

            Console.Write("\nDigite a data de publicação (formato = dd/mm/aaaa): ");
            userInput = Console.ReadLine();

            _ = DateTime.TryParse(userInput, out DateTime publishDate);
            if (publishDate != DateTime.MinValue)
            {
                book.PublishDate = publishDate;
            }

            return book;
        }

        #endregion

    }

}
