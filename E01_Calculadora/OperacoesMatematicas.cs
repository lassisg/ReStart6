using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_Calculadora
{

    public static class OperacoesMatematicas
    {

        static double numero01;
        static double numero02;

        private static void LerNumeros()
        {
            Console.Write("\nDigite o número 1: ");
            numero01 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número 2: ");
            numero02 = Convert.ToDouble(Console.ReadLine());
        }

        public static void Somar()
        {

            Console.WriteLine("Adição");
            
            LerNumeros();

            Console.WriteLine($"\nResultado da operação de adição: {numero01} + {numero02} = {numero01 + numero02}");
        
        }

        public static void Subtrair()
        {

            Console.WriteLine("Subtração");

            LerNumeros();

            Console.WriteLine($"\nResultado da operação de subtração: {numero01} - {numero02} = {numero01 - numero02}");

        }
        
        public static void Multiplicar()
        {

            Console.WriteLine("Multiplicação");

            LerNumeros();

            Console.WriteLine($"\nResultado da operação de multiplicação: {numero01} * {numero02} = {numero01 * numero02}");

        }

        public static void Dividir()
        {

            Console.WriteLine("Divisão");

            LerNumeros();

            Console.WriteLine($"\nResultado da operação de divisão: {numero01} / {numero02} = {numero01 / numero02}");

        }

    }

}
