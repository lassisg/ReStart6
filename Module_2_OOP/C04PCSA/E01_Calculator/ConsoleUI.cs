using D00_Utils;
using System;
using System.Collections.Generic;

namespace E01_Calculator
{

    internal static class ConsoleUI
    {

        #region Properties

        internal static Dictionary<string, string> CalculatorMenu = new Dictionary<string, string>()
        {
            { "1", "Calculadora Padrão" },
            { "2", "Calculadora científica" },
            { "x", "Sair" }
        };

        internal static Dictionary<string, string> MenuStandard = new Dictionary<string, string>()
        {
            { "1", "Adição de 2 números" },
            { "2", "Adição de 3 números" },
            { "3", "Subtração" },
            { "4", "Multiplicação" },
            { "5", "Divisão" },
            { "6", "Arredondamento" },
            { "x", "Sair" }
        };

        internal static Dictionary<string, string> MenuScientific = new Dictionary<string, string>()
        {
            { "1", "Adição" },
            { "2", "Subtração" },
            { "3", "Multiplicação" },
            { "4", "Divisão" },
            { "5", "Raiz quadrada" },
            { "6", "Resto da divisão" },
            { "x", "Sair" }
        };

        #endregion

        #region Methods


        internal static void ShowMenu(Dictionary<string, string> menu, string selectedCalculator = "")
        {

            Utils.PrintHeader($"Calculadora {selectedCalculator}");

            Utils.PrintSubHeader("Escolha uma das opções abaixo.");

            foreach (KeyValuePair<string, string> menuItem in menu)
            {
                string menuOption = menuItem.Value == "Sair" ? "x" : menuItem.Key;
                Console.WriteLine($"{menuOption} - {menuItem.Value}");
            }

            Console.Write($"\nOpção selecionada: ");

        }
       
        internal static string ReadUserInput()
        {

            string userInput = Console.ReadLine();
            return userInput;

        }

        internal static bool ValidateOption(string selectedOption, Dictionary<string, string> options)
        {

            bool isValid = selectedOption == "x" || options.ContainsKey(selectedOption);
            return isValid;

        }

        internal static string ReadNumber(string message)
        {
            
            Console.Write(message);
            string userInput = Console.ReadLine();

            return userInput.Trim();

        }

        internal static bool ValidateNumber(string inputString)
        {

            bool isValid =  double.TryParse(inputString, out _);
            return isValid;

        }

        internal static void ShowResult(string result)
        {

            Console.WriteLine($"\nResultado da operação: {result}");
            Console.ReadKey();

        }

        internal static void WriteErrorMessage(string message)
        {

            string whiteSpace = new string(' ', 3);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n<{whiteSpace}{message}{whiteSpace}>\n");
            Console.ResetColor();
            Console.ReadKey();

        }

        #endregion

    }

}
