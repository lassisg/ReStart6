using D00_Utils;
using System;

namespace D06_EstruturasCondicionais
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region Variáveis

            int numero = 0;
            int valor01 = 1;
            int valor02 = 2;
            bool resultado;

            #endregion

            #region IF simples

            Utils.PrintHeader("IF simples");

            if (numero == 0)
                Console.WriteLine("O número é 0");

            if (numero == 100)
            {
                Console.WriteLine("O número é 100");
            }

            Utils.CleanConsole();

            #endregion

            #region IF ... ELSE

            Utils.PrintHeader("IF ... ELSE");

            if (numero == 100)
            {
                Console.WriteLine("O número é 100");
            }
            else
            {
                Console.WriteLine("O número não é 100");
            }

            Utils.CleanConsole();

            #endregion

            #region Operador Ternário

            Utils.PrintHeader("Operador Ternário");

            // Desafio: ver se os 2 valores são iguais

            Utils.PrintSubHeader("Versão clássica");
            // Verrsão clássica com IF...ELSE
            if (valor01 == valor02)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            Console.WriteLine($"valor01 = valor02 ? {resultado}");

            // Versão com operador ternário
            Utils.PrintSubHeader("Versão com operador ternário");
            
            resultado = (valor01 == valor02) ? true : false;

            Console.WriteLine($"valor01 = valor02 ? {resultado}");

            Utils.CleanConsole();

            #endregion

            #region IFs encadeados

            Utils.PrintHeader("IFs encadeados");

            if (numero == 0)
            {
                Console.WriteLine("O número é 0");
            }
            else
            {
                if (numero == 10)
                {
                    Console.WriteLine("O número é 10");
                }
                else
                {
                    if (numero == 15)
                    {
                        Console.WriteLine("O número é 15");
                    }
                    else
                    {
                        Console.WriteLine("O número não é 0, nem 10, nem 15");
                    }
                }
            }

            Utils.CleanConsole();

            #endregion

            #region IF ... ELSEIF

            Utils.PrintHeader("IF ... ELSEIF");

            if (numero == 0)
            {
                Console.WriteLine("O número é 0");
            }
            else if (numero == 10)
            {
                Console.WriteLine("O número é 10");
            }
            else if (numero == 15)
            {
                Console.WriteLine("O número é 15");
            }
            else
            {
                Console.WriteLine("O número não é 0, nem 10, nem 15");
            }

            Utils.CleanConsole();

            #endregion

            #region SWITCH

            Utils.PrintHeader("SWITCH");

            switch (numero)
            {
                case 0: 
                    Console.WriteLine("O número é 0");
                    break;

                case 10:
                    Console.WriteLine("O número é 10");
                    break;

                case 15:
                    Console.WriteLine("O número é 15");
                    break;

                default:
                    Console.WriteLine("O número não é 0, nem 10, nem 15");
                    break;
            }

            Utils.CleanConsole();

            #endregion

        }

    }

}
