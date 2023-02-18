using D00_Utils;

namespace E01_Calculadora
{

    internal class Program
    {

        // FIX: Review menu exit
        // TODO: Add try...catch blocks

        static void Main(string[] args)
        {

            #region Variables

            CalculadoraSimples calculadora = new CalculadoraSimples();

            bool validOption = true;
            string selectedOption;

            #endregion

            #region Methods

            // Optei por validar a seleção do menu, que inclui o 'x'
            do
            {
                calculadora.ShowMenu(validOption);

                selectedOption = calculadora.ReadSelectedOption();

                validOption = calculadora.ValidateOption(selectedOption);

            } while (!validOption);

            // Uma vez qeu saiu do menu, significa que a seleção é uma das operações ou 'x'
            if (selectedOption != "x")
            {
                calculadora.ReadNumbers();
                calculadora.ExecuteOperation();
                calculadora.ShowResult();
            }

            #endregion

            Utils4.CleanConsole();

        }

    }

}
