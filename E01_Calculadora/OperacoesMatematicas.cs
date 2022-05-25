using System;

namespace E01_Calculadora
{

    public static class OperacoesMatematicas
    {

        static double numero01;
        static double numero02;
        static double resultado;

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

            resultado = numero01 + numero02;
            Console.WriteLine($"\nResultado da operação de adição: {numero01} + {numero02} = {resultado}");
        
        }

        public static void Subtrair()
        {

            Console.WriteLine("Subtração");

            LerNumeros();

            resultado = numero01 - numero02;
            Console.WriteLine($"\nResultado da operação de subtração: {numero01} - {numero02} = {resultado}");

        }
        
        public static void Multiplicar()
        {

            Console.WriteLine("Multiplicação");

            LerNumeros();

            resultado = numero01 * numero02;
            Console.WriteLine($"\nResultado da operação de multiplicação: {numero01} * {numero02} = {resultado}");

        }

        public static void Dividir()
        {

            Console.WriteLine("Divisão");

            LerNumeros();

            resultado = numero01 / numero02;
            Console.WriteLine($"\nResultado da operação de divisão: {numero01} / {numero02} = {resultado}");

        }

    }

}
