using static E01_Calculator.ConsoleUI;

namespace E01_Calculator;

internal class Program
{

    static void Main(string[] args)
    {

        #region Variables

        Calculator calculadora;

        bool isValidOption;
        bool isExit = false;
        string selectedOption;

        #endregion

        do
        {

            ShowMenu(CalculatorMenu);
                
            string selectedCalculator = ReadUserInput();
                
            try
            {
                var teste = CalculatorMenu.ToList();
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
                        if (calculadora is CalculatorStandard)
                        {
                            ShowMenu(MenuStandard, "padrão");
                            selectedOption = ReadUserInput();
                            isValidOption = ValidateOption(selectedOption, MenuStandard);
                        }
                        else if (calculadora is CalculatorScientific)
                        {
                            ShowMenu(MenuScientific, "científica");
                            selectedOption = ReadUserInput();
                            isValidOption = ValidateOption(selectedOption, MenuScientific);
                        }
                        else
                        {
                            throw new InvalidOperationException("Opção inválida!.");
                        }

                        if (!isValidOption)
                        {
                            WriteErrorMessage("Opção inválida!.");
                            continue;
                        }

                        if (selectedOption == "x")
                            break;

                        if (calculadora is CalculatorStandard)
                        {
                            calculadora.Result = ExecuteStandard(calculadora as CalculatorStandard, selectedOption);
                        }
                        else if (calculadora is CalculatorScientific)
                        {
                            calculadora.Result = ExecuteScientific(calculadora as CalculatorScientific, selectedOption);
                        }

                        if (calculadora.Value01 == 0 && calculadora.Result == 0)
                            continue;

                        ShowResult(calculadora.Result.ToString());

                    } while (!isExit) ;
                }

            }
            catch (InvalidOperationException e)
            {
                WriteErrorMessage(e.Message);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                WriteErrorMessage(e.Message);
                Console.ReadKey();
            }
            finally
            {
                Console.Clear();
            }

        } while (!isExit);

    }

    internal static double ExecuteStandard(CalculatorStandard calculator, string selectedOperation)
    {

        double result = 0;
        List<double> inputValues;
        List<Type> inputTypes = new List<Type>();

        switch (selectedOperation)
        {
            case "1":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);
                    
                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Sum(calculator.Value01, calculator.Value02);
                break;

            case "2":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(3, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                calculator.Value03 = inputValues[2];
                result = calculator.Sum(calculator.Value01, calculator.Value02, calculator.Value03);
                break;

            case "3":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Subtract(calculator.Value01, calculator.Value02);
                break;

            case "4":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Multiply(calculator.Value01, calculator.Value02);
                break;

            case "5":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Divide(calculator.Value01, calculator.Value02);
                break;

            case "6":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(int));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = CalculatorStandard.RoundTo(calculator.Value01, (int)calculator.Value02);
                break;

            default:
                WriteErrorMessage("Operação matemática desconhecida.");
                break;
            
        }

        return result;

    }

    internal static double ExecuteScientific(CalculatorScientific calculator, string selectedOperation)
    {

        double result = 0;
        List<double> inputValues;
        List<Type> inputTypes = new List<Type>();

        switch (selectedOperation)
        {
            case "1":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Sum(calculator.Value01, calculator.Value02);
                break;

            case "2":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Subtract(calculator.Value01, calculator.Value02);
                break;

            case "3":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Multiply(calculator.Value01, calculator.Value02);
                break;

            case "4":
                inputTypes.Add(typeof(double));
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = calculator.Divide(calculator.Value01, calculator.Value02);
                break;

            case "5":
                inputTypes.Add(typeof(double));
                inputValues = GetValidNumbers(1, inputTypes);

                calculator.Value01 = inputValues[0];
                result = calculator.GetSquareRoot(calculator.Value01);
                break;

            case "6":
                inputTypes.Add(typeof(int));
                inputTypes.Add(typeof(int));
                inputValues = GetValidNumbers(2, inputTypes);

                calculator.Value01 = inputValues[0];
                calculator.Value02 = inputValues[1];
                result = CalculatorScientific.GetDivisionMod((int)calculator.Value01, (int)calculator.Value02);
                break;

            default:
                WriteErrorMessage("Operação matemática desconhecida.");
                break;

        }

        return result;

    }

    private static bool IsNumeric(string inputString, Type type)
    {
        bool isValid = false;
        if (type == typeof(int))
        {
            isValid = int.TryParse(inputString, out _);
        }
        else if (type == typeof(double))
        {
            isValid = double.TryParse(inputString, out _);
        }
        return isValid;
    }

    internal static List<double> GetValidNumbers(int numbers, List<Type> types)
    {

        bool isNumeric;
        string inputNumber;
        List<double> inputValues = new List<double>();

        for (int i = 1; i <= numbers; i++)
        {
            do
            {
                inputNumber = ReadNumber($"\nDigite o {i}º número: ");
                isNumeric = IsNumeric(inputNumber, types.ElementAt(i-1));
                if (!isNumeric)
                    WriteErrorMessage("Atenção! Digite um número válido: ");

            } while (!isNumeric);

            inputValues.Add(double.Parse(inputNumber));
        }

        return inputValues;

    }

}