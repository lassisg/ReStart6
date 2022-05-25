using System;

namespace E01_Calculadora
{

    internal class Program
    {

        static void Main(string[] args)
        {

            int operacao;

            Console.WriteLine("Que operação deseja fazer?");
            Console.WriteLine("1-Adição");
            Console.WriteLine("2-Subtração");
            Console.WriteLine("3-Multiplicação");
            Console.WriteLine("4-Divisão");
            operacao = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nOperação selecionada: ");

            switch (operacao)
            {
                case 1:
                    OperacoesMatematicas.Somar();
                    break;

                case 2:
                    OperacoesMatematicas.Subtrair();
                    break;

                case 3:
                    OperacoesMatematicas.Multiplicar();
                    break;

                case 4:
                    OperacoesMatematicas.Dividir();
                    break;

                default:
                    Console.WriteLine("Opção incorreta!");
                    break;

            }

            Console.ReadLine();

        }

    }

}
