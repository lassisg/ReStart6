using D00_Utils;
using System;

namespace D07_EstruturasCiclicas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Variáveis

            string valor01 = "";
            string valor02 = "x";
            string nome = string.Empty;

            #endregion

            #region WHILE: pode nunca fazer

            Utils.PrintHeader("WHILE");

            while (valor01 != "x")
            {
                Console.Write("Para saires escreve 'x': ");
                valor01 = Console.ReadLine();
            }

            #endregion

            #region DO ... WHILE: faz pelo menos 1 vez

            Utils.PrintHeader("DO ... WHILE", "\n\n");

            do
            {
                Console.Write("Para saires escreve 'x': ");
                valor02 = Console.ReadLine();
            } while (valor02 != "x");

            #endregion

            #region FOR v1: repetir x número de vezes, incremento

            Utils.PrintHeader("FOR v1", "\n\n");

            // Repetir o ciclo 5 vezes, incremento
            for (int i = 0; i <= 4; i++)        // i = i + 1
            {
                Console.WriteLine($"Número {i}");
            }

            #endregion

            #region FOR v2: repetir x número de vezes, decremento

            Utils.PrintHeader("FOR v2", "\n\n");

            // Repetir o ciclo 5 vezes, decremento
            for (int i = 4; i >= 0; i--)        // i = i - 1
            {
                Console.WriteLine($"Número {i}");
            }

            #endregion

            #region FOR v3: tabuada dos 7

            Utils.PrintHeader("FOR v3 - TABUADA DOS 7", "\n\n");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"7 x {i} = {7 * i}");
            }

            #endregion

            #region FOREACH

            // Primeiro ver estrutura de dados (arrays e collections)

            Utils.PrintHeader("FOREACH", "\n\n");

            Console.WriteLine("Verificar \'D08_EstruturasDados\'...");

            #endregion

            Console.ReadLine();

        }
    }
}
