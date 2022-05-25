using System;

namespace D06_EstruturasCondicionais
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region Variáveis

            int numero = 0;

            #endregion

            #region IF simples

            Utils.PrintHeader("IF simples");

            if (numero == 0)
                Console.WriteLine("O número é 0");

            if (numero == 100)
            {
                Console.WriteLine("O número é 100");
            }

            #endregion

            #region IF ... ELSE

            Utils.PrintHeader("IF ... ELSE", "\n\n");

            if (numero == 100)
            {
                Console.WriteLine("O número é 100");
            }
            else
            {
                Console.WriteLine("O número não é 100");
            }

            #endregion

            #region IFs encadeados

            Utils.PrintHeader("IFs encadeados", "\n\n");

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

            #endregion

            #region IF ... ELSEIF

            Utils.PrintHeader("IF ... ELSEIF", "\n\n");

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

            #endregion

            #region SWITCH

            Utils.PrintHeader("SWITCH", "\n\n");

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

            #endregion

            Console.ReadLine();

        }

    }

}
