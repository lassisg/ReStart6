using D00_Utils;
using E01_Calculadora;

// FIX: Review menu exit
// TODO: Add try...catch blocks

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

Utils.CleanConsole();