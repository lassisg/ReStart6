using D00_Utils;
using System;

namespace M08_VectorsMatrices
{
    internal class Exercicios
    {

        internal static void ExecutarExercicio01()
        {

            Utils.PrintHeader("Exercício 1");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que permita criar um vetor com comprimento 10.";
            subHeader += "\nDepois deve de alterar o valor dos índices 3 e 9.No final deve de";
            subHeader += "\nmostrar a evolução desta troca.";

            Utils.PrintSubHeader(subHeader);

            int[] vetor = new int[10];

            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = (i == 0) ? 0 : vetor[i] + 1;
                vetor[i] = (i <= 2) ? vetor[i] : vetor[i - 1] + vetor[i - 2];
                Console.WriteLine(vetor[i]);
            }

            (vetor[3], vetor[9]) = (vetor[9], vetor[3]);
            
            Console.WriteLine();

            for (int i = 0; i < vetor.Length; i++)
            {
                Console.WriteLine(vetor[i]);
            }

        }

        internal static void ExecutarExercicio02()
        {

            Utils.PrintHeader("Exercício 2");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa para calcular a multiplicação, soma e média de";
            subHeader += "\ntodos os elementos de um vetor com comprimento de 7.";

            Utils.PrintSubHeader(subHeader);

            int[] vetor = new int[7];
            int soma = 0;
            int produto = 1;
            double media;

            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = i + 1;
                vetor[i] = (i > 3) ? vetor[vetor.Length - i-1] : vetor[i];
                Console.WriteLine(vetor[i]);
            }

            for (int i = 0; i < vetor.Length; i++)
            {
                soma += vetor[i];
                produto *= vetor[i];
            }

            media = soma / vetor.Length;

            Console.WriteLine($"\nMédia: {media}");
            Console.WriteLine($"Soma: {soma}");
            Console.WriteLine($"Produto: {produto}");

        }

        internal static void ExecutarExercicio03()
        {

            Utils.PrintHeader("Exercício 3");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa para encontrar o índice e o valor de";
            subHeader = "\nmaior valor.";

            Utils.PrintSubHeader(subHeader);

            int[] vetor = new int[10];
            int max = 0, indice = 0;

            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = (i == 0) ? 0 : vetor[i] + 1;
                vetor[i] = (i <= 2) ? vetor[i] : vetor[i - 1] + vetor[i - 2];
                Console.WriteLine(vetor[i]);
            }

            for (int i = 0; i < vetor.Length; i++)
            {
                max = (max > vetor[i]) ? max : vetor[i];
                indice = (max > vetor[i]) ? indice : i;
            }

            Console.WriteLine($"\nO maior valor é {max}, no índice {indice}");

        }

        internal static void ExecutarExercicio04()
        {

            Utils.PrintHeader("Exercício 4");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que permita criar um vetor com comprimento 8 e";
            subHeader += "\nque recorrendo ao ciclo foreach passe o valor de cada índice para";
            subHeader += "\numa variável inteira.";

            Utils.PrintSubHeader(subHeader);

            

        }

        internal static void ExecutarExercicio05()
        {

            Utils.PrintHeader("Exercício 5");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que leia N números reais para um vetor com o";
            subHeader += "\nmáximo de 100 números e apresente no ecrã a soma dos números.";

            Utils.PrintSubHeader(subHeader);



        }

        internal static void ExecutarExercicio06()
        {

            Utils.PrintHeader("Exercício 6");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método que pesquise num vetor de inteiros V um";
            subHeader += "\ndeterminado número inteiro N e devolva o número de vezes que encontrou";
            subHeader += "\nesse número. Se não encontrar deverá devolver - 1";

            Utils.PrintSubHeader(subHeader);



        }

        internal static void ExecutarExercicio07()
        {

            Utils.PrintHeader("Exercício 7");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever e testar um método para verificar se dois vetores de inteiros";
            subHeader += "\nsão iguais. Dois vetores são iguais se na mesma posição tiverem";
            subHeader += "\nelementos com o mesmo valor.";

            Utils.PrintSubHeader(subHeader);

            

        }

        internal static void ExecutarExercicio08()
        {

            Utils.PrintHeader("Exercício 8");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que leia e apresente um conjunto de números";
            subHeader += "\ninteiros para uma matriz bidimensional 4 x 3";

            Utils.PrintSubHeader(subHeader);



        }

    }

}