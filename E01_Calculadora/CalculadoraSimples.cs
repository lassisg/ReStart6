using D00_Utils;
using System;
using System.Collections;

namespace E01_Calculadora
{
    public class CalculadoraSimples
    {

        #region Properties

        public double Numero01 { get; set; }
        public double Numero02 { get; set; }
        public double Resultado { get; set; }
        public byte Operacao { get; set; }
        public Hashtable MenuOptions { get; set; } = new Hashtable();

        #endregion

        #region Constructors

        public CalculadoraSimples()
        {
            Numero01 =0; 
            Numero02 =0;
            Resultado = 0;
            Operacao = 0;
            MakeMenu();

        }

        public CalculadoraSimples(int numero01, int numero02)
        {
            Numero01 = numero01;
            Numero02 = numero02;
            Resultado = 0;
            Operacao = 0;
            MakeMenu();
        }

        public CalculadoraSimples(int numero01, int numero02, byte operacao)
        {
            Numero01 = numero01;
            Numero02 = numero02;
            Resultado = 0;
            Operacao = operacao;
            MakeMenu();
        }

        #endregion

        #region Methods

        private void MakeMenu()
        {

            //MenuOptions = new string[,]
            //{
            //    { "1", "Adição"},
            //    { "2", "Subtração"},
            //    { "3", "Multiplicação"},
            //    { "4", "Divisão"},
            //    { "x", "Sair"}
            //};

            MenuOptions.Add(1, "Adição");
            MenuOptions.Add(2, "Subtração");
            MenuOptions.Add(3, "Multiplicação");
            MenuOptions.Add(4, "Divisão");

           


        }

        public void ShowMenu() 
        {
            bool isValidOption = true;

            Utils.PrintHeader("Calculadora Simples");
            
            do
            {
                
                if (!isValidOption)
                {

                    Utils.PrintHeader("Calculadora Simples");
                    ShowWarning();
                
                }
                
                Utils.PrintSubHeader("Escolha uma das opções abaixo.");

                for (int i = 0; i < MenuOptions.GetLength(0); i++)
                {
                    Console.WriteLine($"{MenuOptions[i, 0]} - {MenuOptions[i, 1]}");
                }

                Console.Write($"\nOpção selecionada: ");

                string selectedOption = ReadSelectedOption();

                isValidOption = ValidateOption(selectedOption);


            } while (!isValidOption);

        }

        private void ShowWarning()
        {

            Console.Write($"\n{new string('-', 8)}>");
            Console.Write($"{new string(' ', 8)}Por favor selecione uma opção válida{new string(' ', 8)}");
            Console.Write($"<{new string('-', 8)}\n");

        }

        private string ReadSelectedOption()
        {

            return Console.ReadLine();

        }

        private bool ValidateOption(string selectedOption)
        {

            bool isValidOption = true;

            int selection = 2;

            if (MenuOptions.ContainsKey(selectedOption) || selectedOption == 'x')
            {

            }

            switch (selectedOption)
            {
                case "1":
                    Operacao = 0;
                    break;

                case "2":
                    Operacao = 1;
                    break;

                case "3":
                    Operacao = 2;
                    break;

                case "4":
                    Operacao = 3;
                    break;

                case "x":
                    Operacao = 4;
                    break;
                
                default:
                    isValidOption = false;
                    break;
            }

            return isValidOption;

        }

        public void ReadNumbers()
        {

            Console.Write("\nDigite o número 1: ");
            Numero01 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número 2: ");
            Numero02 = Convert.ToDouble(Console.ReadLine());

        }

        public void ExecuteOperation()
        {
            switch (Operacao)
            {

                case 1:
                    Subtratct();
                    break;

                case 2:
                    Multiply();
                    break;

                case 3:
                    Divide();
                    break;

                default:
                    Add();
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

            Console.WriteLine($"\nResultado da operação de \'{MenuOptions[Operacao, 1]}\': {Resultado}");

        }

        #endregion

    }

}
