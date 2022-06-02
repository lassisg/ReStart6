using System;
using System.Linq;

namespace RSGymPT
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CLI myApp = new CLI();
            bool exitApplication;

            do
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();

                try
                {
                    // Fiz split no '-' porque me permite separar o comando no índice 0
                    //   - As opções estarão nos índices seguintes (quando houver)
                    string[] appCommands = userInput.Split('-').Select(c => c.Trim()).ToArray();
                    
                    // Não validei se o comando era 'exit' por questão de responsabilidade do método.
                    // Isto deve ocorrer na CLI
                    exitApplication = myApp.Run(appCommands);

                }
                catch (UnauthorizedAccessException e)
                {
                    WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (ArgumentException e)
                {
                    WriteErrorMessage(e.Message);
                    exitApplication = false;
                }
                catch (Exception e)
                {
                    WriteErrorMessage(e.Message);
                    exitApplication = false;
                }

            } while (!exitApplication);

        }

        private static void WriteErrorMessage(string message)
        {
            string separator = new String('-', 7);

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nERRO:");
            
            Console.ResetColor();
            
            Console.WriteLine(message);
            
            Console.WriteLine($"{separator}\n");
        }

    }

}
