using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_Calculator
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region Variables

            Calculator calculadora;

            bool isExit = false;
            string errorMessage;

            #endregion

            #region Methods

            do
            {
                errorMessage = string.Empty;

                Console.WriteLine("Que tipo de calculadora deseja utilizar?");
                Console.WriteLine("1 - Calculadora padrão");
                Console.WriteLine("2 - Calculadora cinetífica");
                Console.WriteLine("x - Sair");

                string selectedCalculator = Console.ReadLine();
                try
                {

                    switch (selectedCalculator)
                    {
                        case "1":
                            calculadora = new CalculatorStandard();
                            break;

                        case "2":
                            calculadora = new CalculatorScientific();
                            break;

                        case "x":
                            calculadora = null;
                            isExit = true;
                            break;

                        default:
                            throw new InvalidOperationException("Opção inválida!.");
                    }

                    if (!isExit)
                    {
                        do
                        {
                            calculadora.ShowMenu();

                            string selectedOption = calculadora.ReadUserInput();
                            bool isValidOption = calculadora.ValidateOption(selectedOption);

                            if (!isValidOption)
                            {
                                calculadora.WriteErrorMessage("Opção inválida!");
                                continue;
                            }

                            if (selectedOption == "x")
                                break;

                            calculadora.ReadNumbers(selectedOption);
                            calculadora.ExecuteOperation(selectedOption);
                            calculadora.ShowResult();
                            Console.ReadLine();

                        } while (!isExit);
                    }

                }
                catch (InvalidOperationException e)
                {
                    errorMessage = e.Message;
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
                finally
                {
                    if (errorMessage != string.Empty)
                    {
                        string whiteSpace = new string(' ', 3);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\n<{whiteSpace}{errorMessage}{whiteSpace}>\n");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    Console.Clear();
                }

            } while (!isExit);

            #endregion

        }

    }

}
