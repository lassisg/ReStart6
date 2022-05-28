using D00_Utils;
using System;

namespace M07_Methods
{
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

        private static void SayHello(string name)
        {
            Console.WriteLine($"\nOlá, {name}.");
        }

        internal static void ExecutarExercicio02()
        {

            Utils.PrintHeader("Exercício 2");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva e teste um método que devolva a soma de dois números inteiros.";
            subHeader += "\nentre 1 e 50.";

            Utils.PrintSubHeader(subHeader);


        }

        internal static void ExecutarExercicio03()
        {

            Utils.PrintHeader("Exercício 3");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que imprima no ecrã uma linha com";
            subHeader += "\nn asteriscos, em que n é um número introduzido pelo utilizador.";

            Utils.PrintSubHeader(subHeader);


        }

        internal static void ExecutarExercicio04()
        {

            Utils.PrintHeader("Exercício 4");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que simule uma máquina de calcular, de números";
            subHeader += "\ninteiros, em que cada uma das operações soma, subtração, multiplicação";
            subHeader += "\ne divisão é implementada através de um método.";

            Utils.PrintSubHeader(subHeader);


        }


        internal static void ExecutarExercicio05()
        {

            Utils.PrintHeader("Exercício 5");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que devolva o máximo de dois valores.";

            Utils.PrintSubHeader(subHeader);


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


        }

        internal static void ExecutarExercicio07()
        {

            Utils.PrintHeader("Exercício 7");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que receba, como argumento, um valor inteiro";
            subHeader += "\npositivo e devolva o nº de dígitos do valor recebido.";

            Utils.PrintSubHeader(subHeader);

            

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

        }

    }

}