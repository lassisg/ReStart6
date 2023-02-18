using D00_Utils;
using System.Text;

namespace M07_Methods;

internal class Exercicios
{

    internal static void ExecutarExercicio01()
    {
        Utils.PrintHeader("Exercício 1");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Escreva e teste um método que escreva \"Olá, <nome>\".";

        Utils.PrintSubHeader(subHeader);

        Console.Write("Digite o seu nome: ");
        string name = Console.ReadLine();

        SayHello(name);
    }

    private static void SayHello(string name) => Console.WriteLine($"\nOlá, {name}.");

    internal static void ExecutarExercicio02()
    {
        Utils.PrintHeader("Exercício 2");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Escreva e teste um método que devolva a soma de dois números inteiros.";
        subHeader += "\nentre 1 e 50.";

        Utils.PrintSubHeader(subHeader);

        string userInput;
        int num01, num02;
        int soma;
        bool num01isInteger, num02isInteger;

        Console.Write($"Digite o 1º número inteiro: ");
        userInput = Console.ReadLine();
        num01isInteger = int.TryParse(userInput, out num01);

        Console.Write($"Digite o 2º número inteiro: ");
        userInput = Console.ReadLine();
        num02isInteger = int.TryParse(userInput, out num02);

        soma = (num01isInteger && num02isInteger) ? SomaDoisNumeros(num01, num02) : 0;

        if (soma > 0)
            Console.WriteLine($"\nA soma dos números {num01} e {num02} é: {soma}");
        else
            Console.WriteLine($"\nNão foi possível efetuar a soma. Ao menos um dos números não está no formato correto.");
    }

    private static int SomaDoisNumeros(int num01, int num02) => num01 + num02;

    internal static void ExecutarExercicio03()
    {
        Utils.PrintHeader("Exercício 3");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Escrever e testar um método que imprima no ecrã uma linha com";
        subHeader += "\nn asteriscos, em que n é um número introduzido pelo utilizador.";

        Utils.PrintSubHeader(subHeader);

        char symbolToPrint = '*';
        string userInput;

        Console.Write("\nQual símbolo deseja imprimir em tela? (default = '*') ");
        userInput = Console.ReadLine();
            
        symbolToPrint = (userInput == string.Empty) ? symbolToPrint : userInput.ToCharArray()[0];


        Console.Write($"\nQuantas vezes deseja repetir o símbolo '{symbolToPrint}'? (default = 1) ");
        userInput = Console.ReadLine();
            
        _ = int.TryParse(userInput, out int inputValue);
        inputValue = inputValue > 0 ? inputValue : 1;

        PrintSymbols(symbolToPrint, inputValue);
    }

    private static void PrintSymbols(char symbol, int reps) => Console.WriteLine(new String(symbol, reps));

    internal static void ExecutarExercicio04()
    {
        Utils.PrintHeader("Exercício 4");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Escrever um programa que simule uma máquina de calcular, de números";
        subHeader += "\ninteiros, em que cada uma das operações soma, subtração, multiplicação";
        subHeader += "\ne divisão é implementada através de um método.";

        Utils.PrintSubHeader(subHeader);

        Console.WriteLine("\nExercício completo em 'E01_Calculadora_4.7'.");
    }


    internal static void ExecutarExercicio05()
    {
        Utils.PrintHeader("Exercício 5");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Escrever e testar um método que devolva o máximo de dois valores.";

        Utils.PrintSubHeader(subHeader);

        string userInput;
        double num01, num02, max;

        Console.Write("\nDigite um número: ");
        userInput = Console.ReadLine();

        _ = double.TryParse(userInput, out num01);

        Console.Write("\nDigite outro número: ");
        userInput = Console.ReadLine();

        _ = double.TryParse(userInput, out num02);

        max = GetGreaterOf(num01, num02);

        Console.Write($"\nO maior entre os 2 números é: {max}");
    }

    private static double GetGreaterOf(double num01, double num02)
    {
        double max = (num01 > num02) ? num01 : num02;
        return max;
    }

    internal static void ExecutarExercicio06()
    {
        Utils.PrintHeader("Exercício 6");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Escrever e testar um programa que devolva o valor da hipotenusa.";
        subHeader += "\nUsar o método Math.Sqrt()";
        subHeader += "\nhttps://msdn.microsoft.com/pt-br/library/system.math.sqrt(v=vs.100).aspx";

        Utils.PrintSubHeader(subHeader);

        string userInput;
        double hipotenusa;

        Console.Write("Digite o comprimento de uma aresta do triângulo: ");
        userInput= Console.ReadLine();

        _ = double.TryParse(userInput, out double aresta01);

        Console.Write("Digite o comprimento de outra aresta do triângulo: ");
        userInput = Console.ReadLine();

        _ = double.TryParse(userInput, out double aresta02);

        if (aresta01 > 0 && aresta02 > 0)
        {
            hipotenusa = GetHipotenusa(aresta01, aresta02);
            Console.WriteLine($"\nHipotenusa é: {hipotenusa}");
        }
        else
        {
            Console.WriteLine($"\nNão foi possível calcular. Ao menos uma das arestas possui valor inválido.");
        }
    }

    private static double GetHipotenusa(double aresta01, double aresta02)
    {
        double result = Math.Sqrt(Math.Pow(aresta01, 2) + Math.Pow(aresta02, 2));
        return result;
    }

    internal static void ExecutarExercicio07()
    {
        Utils.PrintHeader("Exercício 7");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Escrever e testar um método que receba, como argumento, um valor inteiro";
        subHeader += "\npositivo e devolva o nº de dígitos do valor recebido.";

        Utils.PrintSubHeader(subHeader);

        string userInput;
        bool isInteger;
        int digits;

        Console.Write("\nDigite um número inteiro positivo: ");
        userInput = Console.ReadLine();

        isInteger = int.TryParse(userInput, out int inputValue);

        if (isInteger)
        {
            digits = GetDigits(inputValue);
            Console.WriteLine($"\nO número {userInput} possui {digits} dígitos.");
        }
        else
        {
            Console.WriteLine($"\nO valor digitado não é um númeor inteiro positivo.");
        }
    }

    private static int GetDigits(int integerInput)
    {
        int result = integerInput.ToString().Length;
        return result;
    }

    internal static void ExecutarExercicio08()
    {
        Utils.PrintHeader("Exercício 8");
        string subHeader;
        // ----------------------------------------------------------------------
        subHeader = "Analise o programa e descreva o seu comportamento.";
        subHeader += "\n\nusing System;";
        subHeader += "\nnamespace Cap7";
        subHeader += "\n{";
        subHeader += "\n    class Program";
        subHeader += "\n    {";
        subHeader += "\n        static int Exemplo()";
        subHeader += "\n        {";
        subHeader += "\n            return rnd.Next(1, 7);";
        subHeader += "\n        }";
        subHeader += "\n        static Random rnd = new Random();";
        subHeader += "\n        static void Main(string[] args)";
        subHeader += "\n        {";
        subHeader += "\n            int N, v, contador = 0;";
        subHeader += "\n            Console.Write(\"Quantas vezes quer repetir: \");";
        subHeader += "\n            N = Convert.ToInt32(Console.ReadLine());";
        subHeader += "\n            for (int i = 0; i < N; i++)";
        subHeader += "\n            {";
        subHeader += "\n                if ((v = Exemplo()) == 6)";
        subHeader += "\n                    contador++;";
        subHeader += "\n                Console.WriteLine(v);";
        subHeader += "\n            }";
        subHeader += "\n            Console.WriteLine(\"O número 6 ocorreu {0} vezes\", contador);";
        subHeader += "\n        }";
        subHeader += "\n    }";
        subHeader += "\n}";

        Utils.PrintSubHeader(subHeader);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("\nÉ instanciado um objeto Random na variável 'rnd'.");
        sb.Append("Pede ao utilizador que digite nº de vezer que deseja repetir a operação a seguir.");
        sb.AppendLine("\nDentro da estrutura cíclica 'for', é chamado o método 'Exemplo()', que retorna um valor aleatória entre 1 e 7.");
        sb.AppendLine("Se o valor retornado deo método 'Exemplo()' for iguala à 6, adiciona 1 ao contador.");
        sb.AppendLine("Após o término das repetições, imprime mensagem com a informação de quantas vezes ocorreu o nº 6.");

        Console.WriteLine(sb.ToString());
    }

}