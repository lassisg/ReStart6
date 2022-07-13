using E01_EF6_CF_DAL;
using System;
using System.Linq;

namespace E01_EF6_CF_Client
{

    internal class Program
    {

        static void Main(string[] args)
        {

            bool exitApplication = false;
            string userInput;

            do
            {

                try
                {

                    Utils.WriteMenu();
                    userInput = Console.ReadLine();

                    Console.Clear();

                    switch (userInput)
                    {
                        case "":
                            exitApplication = true;
                            break;

                        case "1":
                            Utils.WriteHeader("Adicionar livro (Enter para sair)");
                            Utils.GetBookDataFromUser()
                                 .ValidateBook()
                                 .Create()
                                 .WriteBookFeedbackMessage();

                            break;

                        case "2":
                            Utils.WriteHeader("Adicionar editora (Enter para sair)");
                            Utils.GetPublisherDataFromUser()
                                 .ValidatePublisher()
                                 .Create()
                                 .WritePublisherFeedbackMessage();

                            break;

                        case "3":
                            Utils.WriteHeader("Lista de livros");
                            BookRepository.GetAllBooks()
                                          .OrderBy(b => b.BookId)
                                          .ToList()
                                          .ForEach(b => Console.WriteLine(b.GetFormattedBook()));

                            break;

                        case "4":
                            Utils.WriteHeader("Lista de editoras");
                            PublisherRepository.GetAllPublishers()
                                               .OrderBy(p => p.PublisherId)
                                               .ToList()
                                               .ForEach(p => Console.WriteLine($"{p.GetFormattedPublisher()}"));

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

            } while (!exitApplication);

            Console.Write("Até logo...");
            Console.ReadLine();

        }

    }

}
