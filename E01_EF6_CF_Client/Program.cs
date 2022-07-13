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

            bool exitApplication = false;
            string userInput;

            do
            {

                try
                {
                    
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
                            BookRepository.GetNewBook().Create();
                            break;

                        case "2":
                            PublisherRepository.GetNewPublisher().Create();
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
