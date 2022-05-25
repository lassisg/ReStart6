using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            #region FOR v1: repetir x número de vezes

            Utils.PrintHeader("FOR v1", "\n\n");

            // Repetir o ciclo 5 vezes, incremento
            for (int i = 0; i <= 4; i++)        // i = i + 1
            {
                Console.WriteLine($"Número {i}");
            }

            #endregion

            #region FOR v2

            Utils.PrintHeader("FOR v2", "\n\n");

            // Repetir o ciclo 5 vezes, decremento
            for (int i = 4; i >= 0; i--)        // i = i - 1
            {
                Console.WriteLine($"Número {i}");
            }

            #endregion

            #region FOR v3

            Utils.PrintHeader("FOR v3", "\n\n");

            #endregion

            #region FOREACH

            Utils.PrintHeader("FOREACH", "\n\n");

            #endregion

            Console.ReadLine();

        }
    }
}
