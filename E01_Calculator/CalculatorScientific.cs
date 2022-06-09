using D00_Utils;
using System;
using System.Collections.Generic;

namespace E01_Calculator
{

    internal class CalculatorScientific : Calculator
    {

        #region Enums

        enum EnumOperation
        {
            None,
            Sum,
            Subtract,
            Multiply,
            Divide,
            SquareRoot,
            Remainder
        }

        #endregion

        #region Properties

        internal override double Value01 { get; set; }
        internal override double Value02 { get; set; }
        internal override double Result { get; set; }

        #endregion

        #region Contructors

        internal CalculatorScientific()
        {
            Value01 = 0;
            Value02 = 0;
            Result = 0;
        }

        internal CalculatorScientific(double value01, double value02)
        {
            Value01 = value01;
            Value02 = value02;
            Result = 0;
        }

        #endregion

        #region Methods

        internal override void ShowMenu()
        {

            Utils.PrintHeader("Calculadora científica");

            Utils.PrintSubHeader("Escolha uma das opções abaixo.");
            
            Dictionary<string, string> menuOptions = GetMenu();

            foreach (KeyValuePair<string, string> item in menuOptions)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.Write($"\nOpção selecionada: ");

        }

        private Dictionary<string, string> GetMenu()
        {

            Dictionary<string, string> menuOptions = new Dictionary<string, string>
            {
                { "1", "Adição" },
                { "2", "Subtração" },
                { "3", "Multiplicação" },
                { "4", "Divisão" },
                { "5", "Raiz quadrada" },
                { "6", "Resto da divisão" },
                { "x", "Sair" }
            };

            return menuOptions;

        }

        internal override string ReadUserInput()
        {

            string userInput = Console.ReadLine();
            return userInput;

        }

        internal override bool ValidateOption(string selectedOption)
        {

            bool isValid = GetMenu().ContainsKey(selectedOption);
            return isValid;

        }

        internal override void ReadNumbers(string selectedOperation)
        {

            string inputString;

            Console.Write("\nDigite o 1º número: ");
            inputString = Console.ReadLine();
            Value01 = ValidateNumber(inputString);

            Console.Write("\nDigite o 2º número: ");
            inputString = Console.ReadLine();
            Value02 = ValidateNumber(inputString);

        }

        internal override double ValidateNumber(string inputString)
        {

            bool isValid = true;
            double inputValue;

            do
            {
                if (!isValid)
                {
                    Console.Write("Atenção! Digite um número válido: ");
                    inputString = Console.ReadLine();
                }

                isValid = double.TryParse(inputString, out inputValue);

            } while (!isValid);

            return Convert.ToDouble(inputValue);

        }

        internal override void ExecuteOperation(string selectedOperation)
        {

            EnumOperation operation = (EnumOperation)int.Parse(selectedOperation);

            switch (operation)
            {
                case EnumOperation.None:
                    throw new Exception("Operação matemática desconhecida.");

                case EnumOperation.Sum:
                    Sum(Value01, Value02);
                    break;

                case EnumOperation.Subtract:
                    Subtract(Value01, Value02);
                    break;

                case EnumOperation.Multiply:
                    Multiply(Value01, Value02);
                    break;

                case EnumOperation.Divide:
                    Divide(Value01, Value02);
                    break;

                case EnumOperation.SquareRoot:
                    GetSquareRoot(Value01);
                    break;

                case EnumOperation.Remainder:
                    int value01 = Convert.ToInt16(Value01);
                    int value02 = Convert.ToInt16(Value02);
                    Result = GetDivisionMod(value01, value02);
                    break;

                default:
                    break;
            }

        }

        internal override void ShowResult()
        {

            Console.WriteLine($"\nResultado da operação: {Result}");

        }

        internal override double Divide(double value01, double value02)
        {

            Result = value01 / value02;
            return Result;

        }

        internal override double Multiply(double value01, double value02)
        {

            Result = value01 * value01;
            return Result;

        }

        internal override double Subtract(double value01, double value02)
        {

            Result = value01 - value02; 
            return Result;

        }

        internal override double Sum(double value01, double value02)
        { 

            Result = value01 + value02; 
            return Result;

        }

        internal double GetSquareRoot(double inputNUmber)
        { 
            Result = Math.Sqrt(inputNUmber); 
            return Result;
        }

        internal static int GetDivisionMod(int dividend, int divisor)
        { 

            Math.DivRem(dividend, divisor, out int result);
            return result;

        }

        internal override void WriteErrorMessage(string message)
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
