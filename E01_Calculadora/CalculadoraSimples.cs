using D00_Utils;
using System;
using System.Collections.Generic;

namespace E01_Calculadora
{
    public class CalculadoraSimples
    {

        #region Properties

        public double Numero01 { get; set; }
        public double Numero02 { get; set; }
        public double Resultado { get; set; }
        public string Operacao { get; set; }
        private Dictionary<string, string> MenuOptions { get; set; }

        #endregion

        #region Constructors

        public CalculadoraSimples()
        {
            // Optei por iniciar sempre as propriedade, inclusive o menu
            Numero01 = 0; 
            Numero02 = 0;
            Operacao = string.Empty;
            Resultado = 0;
            MakeMenu();

        }

        public CalculadoraSimples(int numero01, int numero02)
        {

            Numero01 = numero01;
            Numero02 = numero02;
            Operacao = string.Empty;
            Resultado = 0;
            MakeMenu();

        }

        public CalculadoraSimples(int numero01, int numero02, string operacao)
        {

            Numero01 = numero01;
            Numero02 = numero02;
            Operacao = operacao;
            Resultado = 0;
            MakeMenu();

        }

        #endregion

        #region Methods

        private void MakeMenu()
        {

            MenuOptions = new Dictionary<string, string>();

            MenuOptions.Add("1", "Adição");
            MenuOptions.Add("2", "Subtração");
            MenuOptions.Add("3", "Multiplicação");
            MenuOptions.Add("4", "Divisão");
            MenuOptions.Add("x", "Sair");

        }

        public void ShowMenu(bool isValidOption = true) 
        {

            Utils.PrintHeader("Calculadora Simples");
                           
            if (!isValidOption)
            {

                Utils.PrintHeader("Calculadora Simples");
                ShowWarning();
                
            }
                
            Utils.PrintSubHeader("Escolha uma das opções abaixo.");

            foreach (KeyValuePair<string, string> item in MenuOptions)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.Write($"\nOpção selecionada: ");

        }

        private void ShowWarning()
        {

            Console.Write($"\n{new string('-', 8)}>");
            Console.Write($"{new string(' ', 8)}Por favor selecione uma opção válida{new string(' ', 8)}");
            Console.Write($"<{new string('-', 8)}\n");

        }

        public string ReadSelectedOption()
        {

            return Console.ReadLine();

        }

        public bool ValidateOption(string selectedOption)
        {

            if (MenuOptions.ContainsKey(selectedOption))
            {

                Operacao = selectedOption;

                return true;

            }

            return false;

        }

        public void ReadNumbers()
        {

            string inputString;

            Console.Write("\nDigite o 1º número: ");
            inputString = Console.ReadLine();
            Numero01 = ValidateNumber(inputString);

            Console.Write("\nDigite o 2º número: ");
            inputString = Console.ReadLine();
            Numero02 = ValidateNumber(inputString);

        }

        private double ValidateNumber(string inputString)
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

        public void ExecuteOperation()
        {

            switch (Operacao)
            {

                case "1":
                    Add();
                    break;

                case "2":
                    Subtratct();
                    break;

                case "3":
                    Multiply();
                    break;

                case "4":
                    Divide();
                    break;

                default:
                    break;
            }

        }

        private void Add()
        {

            Resultado = Numero01 + Numero02;

        }

        private void Subtratct()
        {

            Resultado = Numero01 - Numero02;

        }

        private void Multiply()
        {

            Resultado = Numero01 * Numero02;

        }

        private void Divide()
        {

            Resultado = Numero01 / Numero02;

        }

        public void ShowResult()
        {

            Console.WriteLine($"\nResultado da operação de {MenuOptions[Operacao]}: {Resultado}");

        }

        #endregion

    }

}
