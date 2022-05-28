using D00_Utils;
using System;

namespace M09_Strings
{
    internal class Exercicios
    {

        internal static void ExecutarExercicio01()
        {

            Utils.PrintHeader("Exercício 1");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que leia o seu nome e o apresente no ecrã.";

            Utils.PrintSubHeader(subHeader);

            Console.Write("Digite seu nome: ");
            string myName = Console.ReadLine();

            Console.WriteLine($"\nSeu nome é: {myName}");

        }

        internal static void ExecutarExercicio02()
        {

            Utils.PrintHeader("Exercício 2");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um programa que peça um nome completo e mostre só o";
            subHeader += "\nprimeiro e o último nome.";

            Utils.PrintSubHeader(subHeader);

            string fullName;

            Console.Write("Digite seu nome completo: ");
            fullName = Console.ReadLine();

            string[] names = fullName.Split();

            if (names.Length < 2)
            {
                Console.WriteLine($"\nOlá, {names[0]}");
            }
            else
            {
                Console.WriteLine($"\nOlá, {names[0]} {names[names.Length - 1]}");
            }

        }

        internal static void ExecutarExercicio03()
        {

            Utils.PrintHeader("Exercício 3");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um programa que peça o nome e apelidos, um de cada";
            subHeader += "\nvez, e que junte tudo numa única string.";

            Utils.PrintSubHeader(subHeader);

            string firstName, surnames, fullName;

            Console.Write("Digite seu 1º nome: ");
            firstName = Console.ReadLine();

            Console.Write("Digite seus apelidos: ");
            surnames = Console.ReadLine();

            fullName = $"{firstName} {surnames}";

            Console.WriteLine($"\nSeu nome completo é: {fullName}");

        }

        internal static void ExecutarExercicio04()
        {

            Utils.PrintHeader("Exercício 4");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um programa que peça um nome completo e converta";
            subHeader += "\npara maiúsculas o 1º, 3º, 5º nomes.";

            Utils.PrintSubHeader(subHeader);

        }

        internal static void ExecutarExercicio05()
        {

            Utils.PrintHeader("Exercício 5");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que devolva o 1º índice, numa string, de";
            subHeader += "\num carácter introduzido pelo utilizador.";

            Utils.PrintSubHeader(subHeader);

        }

        internal static void ExecutarExercicio06()
        {

            Utils.PrintHeader("Exercício 6");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que devolva quantas vezes um determinado";
            subHeader += "\ncarácter aparece numa string.";

            Utils.PrintSubHeader(subHeader);

        }

        internal static void ExecutarExercicio07()
        {

            Utils.PrintHeader("Exercício 7");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que concatene duas strings introduzidas";
            subHeader += "\npelo utilizador.";

            Utils.PrintSubHeader(subHeader);

        }

        internal static void ExecutarExercicio08()
        {

            Utils.PrintHeader("Exercício 8");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Analise o programa e descreva o seu comportamento";
            subHeader += "\n\nusing System;";
            subHeader += "\n";
            subHeader += "\nnamespace Modulo9";
            subHeader += "\n{";
            subHeader += "\n    class Program";
            subHeader += "\n    {";
            subHeader += "\n        static string Substitui(string s, char c, int de, int ate)";
            subHeader += "\n        {";
            subHeader += "\n            char[] v = s.ToCharArray();";
            subHeader += "\n            for (int k = de; k <= ate; k++)";
            subHeader += "\n            {";
            subHeader += "\n                v[k] = c;";
            subHeader += "\n            }";
            subHeader += "\n            return new string(v);";
            subHeader += "\n        }";
            subHeader += "\n        static void Main(string[] args)";
            subHeader += "\n        {";
            subHeader += "\n            string s;";
            subHeader += "\n            char c;";
            subHeader += "\n            int i, j;";
            subHeader += "\n            Console.Write(\"Introduza uma frase: \");";
            subHeader += "\n            s = Console.ReadLine();";
            subHeader += "\n            Console.Write(\"Introduza o carácter a inserir: \");";
            subHeader += "\n            c = Convert.ToChar(Console.ReadLine());";
            subHeader += "\n            Console.Write(\"Introduza o índice da primeira posição: \");";
            subHeader += "\n            i = Convert.ToInt32(Console.ReadLine());";
            subHeader += "\n            Console.Write(\"Introduza o índice da última posição: \");";
            subHeader += "\n            j = Convert.ToInt32(Console.ReadLine());";
            subHeader += "\n            s = Substitui(s, c, i, j);";
            subHeader += "\n            Console.WriteLine(s);";
            subHeader += "\n        }";
            subHeader += "\n    }";
            subHeader += "\n}";


            Utils.PrintSubHeader(subHeader);

        }

    }

}