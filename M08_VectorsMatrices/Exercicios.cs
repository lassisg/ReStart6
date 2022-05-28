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

            int[] vetor = new int[8];

            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = (i == 0) ? 0 : vetor[i] + 1;
                vetor[i] = (i <= 2) ? vetor[i] : vetor[i - 1] + vetor[i - 2];
            }

            foreach (var item in vetor)
            {
                Console.WriteLine(item);
            }


        }

        internal static void ExecutarExercicio05()
        {

            Utils.PrintHeader("Exercício 5");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escrever um programa que leia N números reais para um vetor com o";
            subHeader += "\nmáximo de 100 números e apresente no ecrã a soma dos números.";

            Utils.PrintSubHeader(subHeader);

            string userInput;
            double[] vetor = new double[100];
            double soma = 0;

            Console.Write("Quantos números deseja introduzir? ");
            userInput = Console.ReadLine();

            _ = int.TryParse(userInput, out int totalNumbers);

            for (int i = 0; i < totalNumbers; i++)
            {
                Console.Write("Digite um número real: ");
                userInput = Console.ReadLine();

                _ = double.TryParse(userInput, out vetor[i]);
            }

            for (int i = 0; i < totalNumbers; i++)
            {
                soma += vetor[i];
            }

            Console.WriteLine($"\nA soma dos valores do vetor é: {soma}");

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

            int numero = 4;
            int[] vetor = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 45 };

            int totalNinV = GetNinV(vetor, numero);

            Console.WriteLine($"\nO número {numero} ocorre {totalNinV} no vetor V.");

        }

        private static int GetNinV(int[] vetor, int numero)
        {
            int totalN = 0;

            for (int i = 0; i < vetor.Length; i++)
            {
                totalN += (vetor[i] == numero) ? 1 : 0;
            }

            return (totalN != 0) ? totalN : -1;
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

            int[] vetor01 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] vetor02 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] vetor03 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            string negacao;

            bool tweens = CheckTweenVectors(vetor01, vetor02);
            negacao = tweens ? "" : "não ";
            Console.WriteLine($"\nOs vetores 1 e 2 {negacao}são iguais.");

            tweens = CheckTweenVectors(vetor01, vetor03);
            negacao = tweens ? "" : "não ";
            Console.WriteLine($"\nOs vetores 1 e 3 {negacao}são iguais.");

            tweens = CheckTweenVectors(vetor02, vetor03);
            negacao = tweens ? "" : "não ";
            Console.WriteLine($"\nOs vetores 2 e 3 {negacao}são iguais.");

        }

        private static bool CheckTweenVectors(int[] vetor01, int[] vetor02)
        {
            bool tweens = true;

            for (int i = 0; i < vetor01.Length; i++)
            {
                if (vetor01[i] != vetor02[i])
                {
                    tweens = false;
                    break;
                }
            }

            return tweens;
        }

        internal static void ExecutarExercicio08()
        {

            Utils.PrintHeader("Exercício 8");
            string subHeader;
            // ----------------------------------------------------------------------
            subHeader = "Escreva um programa que leia e apresente um conjunto de números";
            subHeader += "\ninteiros para uma matriz bidimensional 4 x 3";

            Utils.PrintSubHeader(subHeader);

            int colunas = 4, linhas = 3;
            int[,] matriz = new int[linhas, colunas];
            string userInput;

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    Console.WriteLine($"Digite o valor do elemento na posição ({i+1}, {j+1}) da matriz: ");
                    userInput = Console.ReadLine();

                    _ = int.TryParse(userInput, out matriz[i, j]);
                }
            }

            Console.WriteLine("\nA matriz desenhada é:");
            string linha;

            for (int i = 0; i < linhas; i++)
            {
                linha = "";

                for (int j = 0; j < colunas; j++)
                {
                    linha += $"{matriz[i, j]}  ";
                }

                linha = linha.Trim();

                Console.WriteLine($"{linha}");

            }

        }

    }

}