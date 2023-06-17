using E01_EF6_CF_DAL;
using System;
using System.Linq;

namespace E01_EF6_CF_Client
{

    internal static class Utils
    {

        internal static void WriteMenu()
        {
            Console.WriteLine("O deseja fazer? (escolha o número da opção desejada, 'Enter' para sair)");
            Console.WriteLine("1 - Adicionar livro");
            Console.WriteLine("2 - Adicionar editora");
            Console.WriteLine("3 - Listar livros");
            Console.WriteLine("4 - Listar editoras");
        }

        internal static void WriteHeader(string title)
        {
            string headerBorder = new string('-', 43);
            Console.WriteLine($"{headerBorder}\n{title}\n{headerBorder}\n");
        }

        internal static Publisher GetPublisherDataFromUser()
        {
            Console.Write("Digite o nome da editora: ");
            string userInput = Console.ReadLine();
            var publisher = new Publisher();
            publisher.Name = userInput;

            return publisher;
        }

        internal static Book GetBookDataFromUser()
        {
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
            var publishers = PublisherRepository.GetAllPublishers().OrderBy(p => p.PublisherId).ToList();
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

        internal static void WriteBookFeedbackMessage(this Book book)
        {
            Console.WriteLine($"Livro adicionado com sucesso!");
            Console.WriteLine($"Id: {book.BookId}");
            Console.WriteLine(book.GetFormattedBook());
        }

        internal static void WritePublisherFeedbackMessage(this Publisher publisher)
        {
            Console.WriteLine($"Livro adicionado com sucesso!");
            Console.WriteLine($"{publisher.PublisherId} - {publisher.Name}");
        }

    }

}
