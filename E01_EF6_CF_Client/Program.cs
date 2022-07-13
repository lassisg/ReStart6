using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E01_EF6_CF_DAL;

namespace E01_EF6_CF_Client
{

    internal class Program
    {

        static void Main(string[] args)
        {

            /*
            Livros
            Título          Autor                   ISBN            Editora             Data Pub.
            Siddharta       Hermann Hesse           9789896602079   D. Quixote          -
            Escrítica Pop   Miguel Esteves Cardoso  9789722543538   Bertrand Editora    jul/2022
            */

            bool exitApplication = false;
            string userInput;

            do
            {

                try
                {
                    // ToDo: Aplicar princípios SOLID

                    Console.WriteLine("O deseja fazer? (escolha o número da opção desejada, 'Enter' para sair)");
                    Console.WriteLine("1 - Adicionar livro");
                    Console.WriteLine("2 - Adicionar editora");
                    Console.WriteLine("3 - Listar livros");
                    Console.WriteLine("4 - Listar editoras");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "":
                            exitApplication = true;
                            break;

                        case "1":
                            Console.Clear();
                            Console.WriteLine("----------------------------------\nAdicionar livro (Enter para sair)\n----------------------------------");
                            var book = new Book();

                            Console.Write("\nDigite o título do livro: ");
                            userInput = Console.ReadLine();
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
                            if (publishers.Any(p=>p.PublisherId == publisherId))
                            {
                                book.PublisherId = publisherId;
                            }
                            else
                            {
                                Console.WriteLine("\nEscolha inválida!\n");
                                continue;
                            }

                            Console.Write("\nDigite a data de publicação (formato = dd/mm/aaaa): ");
                            userInput = Console.ReadLine();

                            _ = DateTime.TryParse(userInput, out DateTime publishDate);
                            if (publishDate != DateTime.MinValue)
                            {
                                book.PublishDate = publishDate;
                            }

                            book.Create();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("----------------------------------\nAdicionar editora (Enter para sair)\n----------------------------------");
                            Console.Write("Digite o nome da editora: ");
                            userInput = Console.ReadLine();
                            var editora = new Publisher();
                            editora.Name = userInput;
                            editora.Create();

                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("----------------------------------\nLista de livros\n----------------------------------");
                            BookRepository.ListAll()
                                .OrderBy(b => b.Title)
                                .ToList()
                                .ForEach(b => Console.WriteLine($"Título: {b.Title}, ISBN: {b.ISBN}, Autor: {b.Author}, Editora: {PublisherRepository.GetPublisherById(b.PublisherId).Name}"));
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("----------------------------------\nLista de editoras\n----------------------------------");
                            PublisherRepository.ListAll()
                                .OrderBy(p => p.Name)
                                .ToList()
                                .ForEach(p => Console.WriteLine($"{p.Name}"));
                            break;

                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }

                    Console.WriteLine();


                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Ocorreu um erro!\n{e.Message}\n");
                }
                finally
                {
                    
                }

            } while (!exitApplication);

            Console.Write("Até logo...");
            Console.ReadLine();

        }

    }

}
